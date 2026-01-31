using Units.Domain.TargetStrategy.Interfaces;
using UnityEngine;

namespace Units.Domain.TargetStrategy.Schemes
{
    [CreateAssetMenu(menuName = "Configs/Targeting/ClosestEnemy")]
    public class ClosestEnemyScheme : TargetingScheme
    {
        public override ITargetStrategy CreateStrategy(UnitRegistry registry)
        {
            return new ClosestEnemyStrategy(registry);
        }
    }
}