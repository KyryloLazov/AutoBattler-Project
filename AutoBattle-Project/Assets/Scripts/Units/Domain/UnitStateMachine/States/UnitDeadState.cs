using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitDeadState : UnitBaseState
    {
        public UnitDeadState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade, ITargetStrategy targetStrategy) 
            : base(unitStateMachine, unitFacade, targetStrategy) { }

        public override void OnEnter()
        {
            UnitFacade.gameObject.SetActive(false);
        }
    }
}