using System;
using System.Linq;
using GameLoop.Domain.GameplayLoopStateMachine;
using UniRx;
using Units.Domain;
using Zenject;

namespace BattlePhase
{
    public class BattleService : IInitializable, IDisposable
    {
        private readonly UnitRegistry _registry;
        private readonly GameContextData _contextData;
        private readonly CompositeDisposable _disposables = new();

        public BattleService(UnitRegistry registry, GameContextData contextData)
        {
            _registry = registry;
            _contextData = contextData;
        }

        public void Initialize()
        {
            _registry.TeamCounts.ObserveAdd().Select(_ => Unit.Default)
                .Merge(_registry.TeamCounts.ObserveRemove().Select(_ => Unit.Default),
                _registry.TeamCounts.ObserveReplace().Select(_ => Unit.Default),
                _registry.TeamCounts.ObserveReset().Select(_ => Unit.Default)
            ).Subscribe(_ => CheckWinCondition()).AddTo(_disposables);
        }

        private void CheckWinCondition()
        {
            if (_contextData.CurrentPhase.Value != GamePhase.Battle) return;
            if (_contextData.IsGameOver.Value) return;
            
            var activeTeams = _registry.TeamCounts
                .Where(kvp => kvp.Value > 0)
                .Select(kvp => kvp.Key)
                .ToList();
            
            if (activeTeams.Count == 1)
            {
                FinishBattle(BattleResult.Win(activeTeams[0]));
            }
            else if (activeTeams.Count == 0)
            {
                FinishBattle(BattleResult.Draw());
            }
        }

        private void FinishBattle(BattleResult result)
        {
            if (_contextData.IsGameOver.Value) return;

            _contextData.LastBattleResult.Value = result;
            _contextData.IsGameOver.Value = true;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }

}