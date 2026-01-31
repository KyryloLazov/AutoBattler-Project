using Units.Domain;

namespace GameLoop.Domain.GameplayLoopStateMachine
{
    public struct BattleResult
    {
        public readonly bool IsDraw;
        public readonly UnitTeam Winner;
        
        public static BattleResult Draw() 
        {
            return new BattleResult(true, default);
        }

        public static BattleResult Win(UnitTeam winner) 
        {
            return new BattleResult(false, winner);
        }

        private BattleResult(bool isDraw, UnitTeam winner)
        {
            IsDraw = isDraw;
            Winner = winner;
        }
    }
}