using Units.Domain.UnitStateMachine.States;

namespace Units.Domain.UnitStateMachine.Handlers
{
    public class UnitIdleHandler : IStateHandle
    {
        private readonly InitializationUnitStateMachine _fsm;

        public UnitIdleHandler(InitializationUnitStateMachine fsm)
        {
            _fsm = fsm;
        }

        public bool CanHandle()
        {
            return _fsm.RuntimeData.Target.Value == null;
        }

        public void Handle()
        {
            _fsm.StateMachine.SwitchStates<UnitIdleState>();
        }
    }
}