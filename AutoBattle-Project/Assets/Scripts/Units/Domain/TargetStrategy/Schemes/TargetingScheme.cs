using Units.Domain.TargetStrategy.Interfaces;
using UnityEngine;

namespace Units.Domain.TargetStrategy.Schemes
{
    public abstract class TargetingScheme : ScriptableObject
    {
        public abstract ITargetStrategy CreateStrategy(UnitRegistry registry);
    }
}