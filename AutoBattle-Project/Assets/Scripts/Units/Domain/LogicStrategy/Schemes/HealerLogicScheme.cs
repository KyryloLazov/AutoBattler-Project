using Units.Domain.LogicStrategy.Interfaces;
using Units.Domain.LogicStrategy.Strategies;
using UnityEngine;

namespace Units.Domain.LogicStrategy.Schemes
{
    [CreateAssetMenu(menuName = "Configs/Logic/HealerScheme")]
    public class HealerLogicScheme : UnitLogicScheme
    {
        public override IUnitLogicStrategy GetStrategy()
        {
            return new HealerUnitStrategy();
        }
    }
}