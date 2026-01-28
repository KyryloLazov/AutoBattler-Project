using GameLoop.Domain.GameplayLoopStateMachine.States;

namespace GameLoop.Domain.GameplayLoopStateMachine.Handlers
{
    public class BattleStateHandler : IStateHandle
    {
        private readonly InitializationGameLoopStateMachine _facade;

        public BattleStateHandler(InitializationGameLoopStateMachine facade)
        {
            _facade = facade;
        }

        public bool CanHandle()
        {
            bool isAlreadyInBattle = _facade.StateMachine.currentStates is BattleState;
            return _facade.ContextData.IsBattleRequested.Value && !isAlreadyInBattle;
        }

        public void Handle()
        {
            _facade.ContextData.IsBattleRequested.Value = false;
            _facade.StateMachine.SwitchStates<BattleState>();
        }
    }
}