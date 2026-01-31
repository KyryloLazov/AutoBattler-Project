using Units.Presentation;
using UnityEngine;

namespace Units.Domain.TargetStrategy.Interfaces
{
    public interface ITargetStrategy
    {
        Transform FindTarget(UnitFacade self);
    }
}