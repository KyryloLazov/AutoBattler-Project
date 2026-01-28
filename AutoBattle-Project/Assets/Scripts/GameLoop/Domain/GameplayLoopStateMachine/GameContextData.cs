using UniRx;

namespace GameLoop.Domain.GameplayLoopStateMachine
{
    public class GameContextData
    {
        public readonly ReactiveProperty<bool> IsBattleRequested = new(false);
        public readonly ReactiveProperty<bool> IsRestartRequested = new(false);
        public readonly ReactiveProperty<bool> IsGameOver = new(false);
        public readonly ReactiveProperty<string> WinnerInfo = new(string.Empty);
    }
}