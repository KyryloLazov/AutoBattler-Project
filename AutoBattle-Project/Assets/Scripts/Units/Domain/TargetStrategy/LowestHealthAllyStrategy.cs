using System.Linq;
using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.TargetStrategy
{
    public class LowestHealthAllyStrategy : ITargetStrategy
    {
        private readonly UnitRegistry _registry;

        public LowestHealthAllyStrategy(UnitRegistry registry)
        {
            _registry = registry;
        }

        public Transform FindTarget(UnitFacade self)
        {
            var allies = _registry.GetUnits(self.Team)
                .Where(u => u != self)
                .Where(u => u.UnitFsm.RuntimeData.Health.Value < u.UnitFsm.RuntimeData.MaxHp);

            UnitFacade lowestHpUnit = null;
            float minHp = float.MaxValue;

            foreach (var ally in allies)
            {
                float currentHp = ally.UnitFsm.RuntimeData.Health.Value;
                if (currentHp < minHp)
                {
                    minHp = currentHp;
                    lowestHpUnit = ally;
                }
            }

            return lowestHpUnit != null ? lowestHpUnit.transform : null;
        }
    }
}