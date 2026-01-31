using UnitPlacement.Domain;
using Units.Domain;
using Units.Infrastructure.Config;
using Units.Presentation;
using UnityEngine;
using Zenject;

namespace UnitPlacement.Presentation
{
    public class PlacementController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private PlacementModel _model;
        private UnitFactory _unitFactory;
        private BattleFieldService _fieldService;

        [Inject]
        public void Construct(
            PlacementModel model,
            UnitFactory unitFactory,
            BattleFieldService fieldService)
        {
            _model = model;
            _unitFactory = unitFactory;
            _fieldService = fieldService;
        }

        public void Update()
        {
            if (_model.SelectedUnitConfig.Value == null) return;

            if (Input.GetMouseButtonDown(0))
            {
                HandleClick();
            }
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
    }
}