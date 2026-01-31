using GameLoop.Domain.GameplayLoopStateMachine.Handlers;

namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class GameBaseState : IState
    {
        protected GameContextData GameContextData;
        protected InitializationGameLoopStateMachine GameLoopStateMachine;

        public GameBaseState(GameContextData gameContextData, InitializationGameLoopStateMachine gameLoopStateMachine)
        {
            GameContextData = gameContextData;
            GameLoopStateMachine = gameLoopStateMachine;
        }
        
        public virtual void OnEnter()
        { }

        public virtual void OnExit()
        {
        }

        public virtual void Update()
        {
            // GameLoopStateMachine.StateHandleChain.HandleState<PlacementStateHandler>();
            // GameLoopStateMachine.StateHandleChain.HandleState<BattleStateHandler>();
            // GameLoopStateMachine.StateHandleChain.HandleState<ResultStateHandler>();
        }

        public virtual void FixedUpdate()
        {
        }
    }
}