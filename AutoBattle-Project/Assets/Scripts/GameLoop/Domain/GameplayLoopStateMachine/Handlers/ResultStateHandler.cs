using GameLoop.Domain.GameplayLoopStateMachine.States;

namespace GameLoop.Domain.GameplayLoopStateMachine.Handlers
{
    public class ResultStateHandler : IStateHandle
    {
        private readonly InitializationGameLoopStateMachine _facade;

        public ResultStateHandler(InitializationGameLoopStateMachine facade)
        {
            _facade = facade;
        }

        public bool CanHandle()
        {
            bool isAlreadyInResult = _facade.StateMachine.currentStates is ResultState;
            return _facade.ContextData.IsGameOver.Value && !isAlreadyInResult;
        }

        public void Handle()
        {
            _facade.StateMachine.SwitchStates<ResultState>();
        }
    }
}