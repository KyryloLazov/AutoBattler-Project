using GameLoop.Domain.GameplayLoopStateMachine.States;

namespace GameLoop.Domain.GameplayLoopStateMachine.Handlers
{
    public class PlacementStateHandler : IStateHandle
    {
        private readonly InitializationGameLoopStateMachine _facade;

        public PlacementStateHandler(InitializationGameLoopStateMachine facade)
        {
            _facade = facade;
        }

        public bool CanHandle()
        {
            return _facade.ContextData.IsRestartRequested.Value;
        }

        public void Handle()
        {
            _facade.ContextData.IsRestartRequested.Value = false;
            _facade.ContextData.IsGameOver.Value = false;
            _facade.StateMachine.SwitchStates<PlacementState>();
        }
    }
}