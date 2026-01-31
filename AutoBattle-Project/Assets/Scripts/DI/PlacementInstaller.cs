using UnitPlacement.Domain;
using UnitPlacement.Infrastructure.Config;
using UnitPlacement.Presentation;
using Units.Domain;
using Units.Infrastructure.Config;
using UnityEngine;

namespace DI
{
    public class PlacementInstaller : BaseBindings
    {
        [SerializeField] private PlacementView _placementView;
        [SerializeField] private TeamColorConfig _teamColorConfig;
        [SerializeField] private UnitsDatabase _unitsDatabase;
        [SerializeField] private PlacementController _placementController;

        public override void InstallBindings()
        {
            BindInstance(_teamColorConfig);
            BindInstance(_unitsDatabase);
            BindInstance(_placementView);
            BindInstance(_placementController);
            BindNewInstance<UnitRegistry>();
            BindNewInstance<UnitFactory>();
            BindNewInstance<BattleFieldService>();
            BindNewInstance<PlacementModel>();
            BindNewInstance<PlacementPresenter>();
        }
    }
}