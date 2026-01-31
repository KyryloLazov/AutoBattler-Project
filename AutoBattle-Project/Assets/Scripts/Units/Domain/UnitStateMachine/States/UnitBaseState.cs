using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;

namespace Units.Domain.UnitStateMachine.States
{

    public abstract class UnitBaseState : IState
    {
        protected readonly InitializationUnitStateMachine UnitStateMachine;
        protected readonly UnitFacade UnitFacade;
        protected readonly ITargetStrategy TargetStrategy;

        protected UnitBaseState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade,
            ITargetStrategy targetStrategy)
        {
            UnitStateMachine = unitStateMachine;
            UnitFacade = unitFacade;
            TargetStrategy = targetStrategy;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}