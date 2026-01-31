using UniRx;
using Units.Infrastructure.Config;

namespace UnitPlacement.Domain
{
    public class PlacementModel
    {
        public ReactiveProperty<UnitStatsConfig> SelectedUnitConfig = new();
    }
}