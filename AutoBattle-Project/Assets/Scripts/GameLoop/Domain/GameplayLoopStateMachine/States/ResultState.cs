namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class ResultState : GameBaseState
    {
        public ResultState(GameContextData gameContextData, InitializationGameLoopStateMachine gameLoopStateMachine) 
            : base(gameContextData, gameLoopStateMachine) { }

        public override void OnEnter()
        {
            GameContextData.CurrentPhase.Value = GamePhase.Result;
        }
        public override void OnExit() { }
        public override void Update() { }
        public override void FixedUpdate() { }
    }
}