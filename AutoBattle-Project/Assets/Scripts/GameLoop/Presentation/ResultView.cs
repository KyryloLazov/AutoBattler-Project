using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoop.Presentation
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TMP_Text _resultText;
        
        [SerializeField] private Image _backgroundImage; 

        public void Show() => _panel.SetActive(true);
        public void Hide() => _panel.SetActive(false);

        public void SetText(string text, Color color)
        {
            _resultText.text = text;
            _resultText.color = color;
        }
        
        public void SetBackgroundColor(Color color)
        {
            if (_backgroundImage != null) _backgroundImage.color = color;
        }
    }
}