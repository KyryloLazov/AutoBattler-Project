using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitIdleState : UnitBaseState
    {
        public UnitIdleState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade, ITargetStrategy targetStrategy) 
            : base(unitStateMachine, unitFacade, targetStrategy) { }

        public override void Update()
        { }
    }
}