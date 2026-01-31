using System;
using GameLoop.Domain.GameplayLoopStateMachine;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameLoop.Presentation
{
    public class GameHudPresenter : IInitializable, IDisposable
    {
        private readonly GameHudView _view;
        private readonly GameContextData _context;
        private readonly CompositeDisposable _disposables = new();

        public GameHudPresenter(GameHudView view, GameContextData context)
        {
            _view = view;
            _context = context;
        }

        public void Initialize()
        {
            _view.OnStartClick
                .Subscribe(_ => _context.IsBattleRequested.Value = true)
                .AddTo(_disposables);

            _view.OnRestartClick
                .Subscribe(_ => _context.IsRestartRequested.Value = true)
                .AddTo(_disposables);
            
            _context.CurrentPhase
                .Subscribe(UpdateStateVisuals)
                .AddTo(_disposables);
        }

        private void UpdateStateVisuals(GamePhase phase)
        {
            switch (phase)
            {
                case GamePhase.Placement:
                    _view.SetStartButtonActive(true);
                    _view.SetRestartButtonActive(false);
                    break;

                case GamePhase.Battle:
                    _view.SetStartButtonActive(false);
                    _view.SetRestartButtonActive(true);
                    break;

                case GamePhase.Result:
                    _view.SetStartButtonActive(false);
                    _view.SetRestartButtonActive(true);
                    break;
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}