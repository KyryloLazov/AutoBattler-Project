using UnitPlacement.Domain;
using Units.Domain;
using Units.Infrastructure.Config;
using Units.Presentation;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UnitPlacement.Presentation
{
    public class PlacementController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _unitLayer;
        
        private PlacementModel _model;
        private UnitFactory _unitFactory;
        private BattleFieldService _fieldService;
        private UnitRegistry _registry;

        [Inject]
        public void Construct(
            PlacementModel model,
            UnitFactory unitFactory,
            BattleFieldService fieldService,
            UnitRegistry registry)
        {
            _model = model;
            _unitFactory = unitFactory;
            _fieldService = fieldService;
            _registry = registry;
        }

        public void Update()
        {
            if (_model.SelectedUnitConfig.Value == null) return;

            if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
            {
                HandleClick();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                HandleRightClick();
            }
        }
        
        private bool IsPointerOverUI()
        {
            return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
        }

        private void HandleClick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 position = hit.point;
            
                if (_fieldService.IsPositionValid(position))
                {
                    SpawnUnit(position);
                }
            }
        }
        
        private void HandleRightClick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, _unitLayer))
            {
                if (hit.collider.TryGetComponent<UnitFacade>(out var unit))
                {
                    RemoveUnit(unit);
                }
            }
        }

        private void SpawnUnit(Vector3 position)
        {
            UnitTeam team = _fieldService.GetTeamForPosition(position);
            UnitStatsConfig config = _model.SelectedUnitConfig.Value;

           UnitFacade unit = _unitFactory.Create(config, team);
           
           if (unit.TryGetComponent<Renderer>(out var unitRenderer))
           {
               float height = unitRenderer.bounds.size.y;
               position.y += height * 0.5f; 
           }

           unit.transform.position = position;
        }
        
        private void RemoveUnit(UnitFacade unit)
        {
            _registry.Unregister(unit);
            Destroy(unit.gameObject);
        }
    }
}