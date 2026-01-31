using Units.Domain.UnitStateMachine.States;

namespace Units.Domain.UnitStateMachine.Handlers
{
    public class UnitDeadHandler : IStateHandle
    {
        private readonly InitializationUnitStateMachine _fsm;

        public UnitDeadHandler(InitializationUnitStateMachine fsm)
        {
            _fsm = fsm;
        }

        public bool CanHandle()
        {
            return _fsm.RuntimeData.IsDead.Value;
        }

        public void Handle()
        {
            _fsm.StateMachine.SwitchStates<UnitDeadState>();
        }
    }
}