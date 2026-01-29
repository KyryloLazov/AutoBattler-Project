using GameLoop.Domain.GameplayLoopStateMachine.States;

namespace GameLoop.Domain.GameplayLoopStateMachine
{
    public class InitializationGameLoopStateMachine
    {
        public StateMachine StateMachine { get; private set; }
        public GameContextData ContextData { get; private set; }
        public StateHandleChain StateHandleChain { get; private set; }

        private PlacementState _placementState;
        private BattleState _battleState;
        private ResultState _resultState;

        public InitializationGameLoopStateMachine(
            GameContextData contextData,
            StateHandleChain handleChain)
        {
            ContextData = contextData;
            StateHandleChain = handleChain;

            Initialize();
        }

        private void Initialize()
        {
            _battleState = new BattleState(ContextData, this);
            _placementState = new PlacementState(ContextData, this);
            _resultState = new ResultState(ContextData, this);
            
            StateMachine = new StateMachine(_placementState, _battleState, _resultState);
            StateMachine.SwitchStates<PlacementState>();
        }
    }
}