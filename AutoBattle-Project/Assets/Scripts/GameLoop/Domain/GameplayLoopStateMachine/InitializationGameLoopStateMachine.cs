using GameLoop.Domain.GameplayLoopStateMachine.States;

namespace GameLoop.Domain.GameplayLoopStateMachine
{
    public class InitializationGameLoopStateMachine
    {
        public StateMachine StateMachine { get; private set; }
        public GameContextData ContextData { get; private set; }

        private PlacementState _placementState;
        private BattleState _battleState;
        private ResultState _resultState;
        private readonly StateHandleChain _handleChain;

        public InitializationGameLoopStateMachine(
            GameContextData contextData,
            StateHandleChain handleChain)
        {
            ContextData = contextData;
            _handleChain = handleChain;

            Initialize();
        }

        private void Initialize()
        {
            _battleState = new BattleState(ContextData);
            _placementState = new PlacementState();
            _resultState = new ResultState();
            
            StateMachine = new StateMachine(_placementState, _battleState, _resultState);
            StateMachine.SwitchStates<PlacementState>();
        }

        // public void Tick()
        // {
        //     if (StateMachine == null) return;
        //     _handleChain.HandleState();
        //
        //     if (StateMachine.isUpdate && StateMachine.currentStates != null)
        //     {
        //         StateMachine.currentStates.Update();
        //     }
        // }
    }
}