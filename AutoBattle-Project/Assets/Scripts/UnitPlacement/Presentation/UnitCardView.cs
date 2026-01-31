using System;
using TMPro;
using UniRx;
using Units.Infrastructure.Config;
using UnityEngine;
using UnityEngine.UI;

namespace UnitPlacement.Presentation
{
    public class UnitCardView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private GameObject _highlight;

        public UnitStatsConfig Config { get; private set; }

        public IObservable<Unit> OnClick => _button.OnClickAsObservable();

        public void Setup(UnitStatsConfig config)
        {
            Config = config;
            _nameText.text = config.UnitName;
            _iconImage.sprite = config.Icon;
            SetSelected(false);
        }

        public void SetSelected(bool isSelected)
        {
            _highlight.SetActive(isSelected);
        }
    }
}