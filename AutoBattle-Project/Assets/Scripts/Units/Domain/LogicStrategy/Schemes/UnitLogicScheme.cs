using Units.Domain.LogicStrategy.Interfaces;
using UnityEngine;

namespace Units.Domain.LogicStrategy.Schemes
{
    public abstract class UnitLogicScheme : ScriptableObject
    {
        public abstract IUnitLogicStrategy GetStrategy();
    }
}