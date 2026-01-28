using GameLoop.Domain.GameplayLoopStateMachine;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameLoop.Domain
{
    public class GameHudPresenter : MonoBehaviour
    {
        [SerializeField] private Button _startBtn;
        [SerializeField] private Button _restartBtn;

        [Inject] private GameContextData _context;

        private void Start()
        {
            _startBtn.OnClickAsObservable()
                .Subscribe(_ => _context.IsBattleRequested.Value = true)
                .AddTo(this);

            _restartBtn.OnClickAsObservable()
                .Subscribe(_ => _context.IsRestartRequested.Value = true)
                .AddTo(this);
        }
    }
}