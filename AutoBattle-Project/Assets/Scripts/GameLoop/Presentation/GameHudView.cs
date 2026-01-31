using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoop.Presentation
{
    public class GameHudView : MonoBehaviour
    {
        [SerializeField] private Button _startBtn;
        [SerializeField] private Button _restartBtn;
        [SerializeField] private GameObject _panel;

        public IObservable<Unit> OnStartClick => _startBtn.OnClickAsObservable();
        public IObservable<Unit> OnRestartClick => _restartBtn.OnClickAsObservable();

        public void SetStartButtonActive(bool isActive)
        {
            _startBtn.gameObject.SetActive(isActive);
        }

        public void SetRestartButtonActive(bool isActive)
        {
            _restartBtn.gameObject.SetActive(isActive);
        }

        public void SetInteractable(bool isInteractable)
        {
            _panel.SetActive(isInteractable);
        }
    }
}