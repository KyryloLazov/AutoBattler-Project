namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class BattleState : IState
    {
        private readonly GameContextData _context;

        public BattleState(GameContextData context)
        {
            _context = context;
        }

        public void OnEnter() { }
        public void OnExit() { }
        public void Update() { }
        public void FixedUpdate() { }
    }
}