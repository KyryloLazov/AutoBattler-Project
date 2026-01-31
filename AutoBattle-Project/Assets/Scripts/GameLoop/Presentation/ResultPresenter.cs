using System;
using GameLoop.Domain.GameplayLoopStateMachine;
using UniRx;
using UnitPlacement.Infrastructure.Config;
using Units.Domain;
using UnityEngine;
using Zenject;

namespace GameLoop.Presentation
{
    public class ResultPresenter : IInitializable, IDisposable
    {
        private readonly ResultView _view;
        private readonly GameContextData _context;
        private readonly TeamColorConfig _colorConfig;
        private readonly CompositeDisposable _disposables = new();

        public ResultPresenter(
            ResultView view, 
            GameContextData context,
            TeamColorConfig colorConfig)
        {
            _view = view;
            _context = context;
            _colorConfig = colorConfig;
        }

        public void Initialize()
        {
            _context.CurrentPhase
                .Subscribe(OnPhaseChanged)
                .AddTo(_disposables);
        }

        private void OnPhaseChanged(GamePhase phase)
        {
            if (phase == GamePhase.Result)
            {
                DisplayResult(_context.LastBattleResult.Value);
                _view.Show();
            }
            else
            {
                _view.Hide();
            }
        }

        private void DisplayResult(BattleResult result)
        {
            if (result.IsDraw)
            {
                _view.SetText("DRAW!", Color.white);
                _view.SetBackgroundColor(Color.gray);
            }
            else
            {
                string winnerName = result.Winner.ToString().ToUpper();
                Color teamColor = _colorConfig.GetMaterial(result.Winner).color;

                _view.SetText($"{winnerName} WINS!", teamColor);
                _view.SetBackgroundColor(teamColor * 0.5f); 
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}