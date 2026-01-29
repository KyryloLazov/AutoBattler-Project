namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class BattleState : GameBaseState
    {
        public BattleState(GameContextData gameContextData, InitializationGameLoopStateMachine gameLoopStateMachine) 
            : base(gameContextData, gameLoopStateMachine) { }

        public void OnEnter() { }
        public void OnExit() { }
        public void Update() { }
        public void FixedUpdate() { }
    }
}