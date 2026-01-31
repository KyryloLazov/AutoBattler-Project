using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.TargetStrategy
{
    public class ClosestEnemyStrategy : ITargetStrategy
    {
        private readonly UnitRegistry _registry;

        public ClosestEnemyStrategy(UnitRegistry registry)
        {
            _registry = registry;
        }

        public Transform FindTarget(UnitFacade self)
        {
            UnitTeam enemyTeam = self.Team == UnitTeam.Blue ? UnitTeam.Red : UnitTeam.Blue;
            var enemies = _registry.GetUnits(enemyTeam);

            UnitFacade closestUnit = null;
            float minDistance = float.MaxValue;
            Vector3 currentPos = self.transform.position;

            foreach (var enemy in enemies)
            {
                float dist = Vector3.SqrMagnitude(enemy.transform.position - currentPos);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestUnit = enemy;
                }
            }

            return closestUnit != null ? closestUnit.transform : null;
        }
    }
}