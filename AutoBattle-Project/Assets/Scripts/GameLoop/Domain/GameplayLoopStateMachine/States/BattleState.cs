using UnityEngine;

namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class BattleState : GameBaseState
    {
        public BattleState(GameContextData gameContextData, InitializationGameLoopStateMachine gameLoopStateMachine) 
            : base(gameContextData, gameLoopStateMachine) { }

        public override void OnEnter()
        {
            GameContextData.CurrentPhase.Value = GamePhase.Battle;
            Debug.Log("Enter Battle State");
        }
        public override void OnExit() { }
        public override void Update() { }
        public override void FixedUpdate() { }
    }
}