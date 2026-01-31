using Units.Domain.TargetStrategy.Interfaces;
using Units.Domain;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.TargetStrategy.Schemes
{
    [CreateAssetMenu(menuName = "Configs/Targeting/LowestHealthAlly")]
    public class LowestHealthAllyScheme : TargetingScheme
    {
        public override ITargetStrategy CreateStrategy(UnitRegistry registry)
        {
            return new LowestHealthAllyStrategy(registry);
        }
    }
}