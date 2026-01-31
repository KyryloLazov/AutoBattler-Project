using Units.Domain.LogicStrategy.Interfaces;
using Units.Domain.LogicStrategy.Strategies;
using UnityEngine;

namespace Units.Domain.LogicStrategy.Schemes
{
    [CreateAssetMenu(menuName = "Configs/Logic/MeleeScheme")]
    public class MeleeLogicScheme : UnitLogicScheme
    {
        public override IUnitLogicStrategy GetStrategy()
        {
            return new MeleeUnitStrategy();
        }
    }
}