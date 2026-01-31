using System.Collections.Generic;
using Units.Infrastructure.Config;
using UnityEngine;

namespace UnitPlacement.Presentation
{
    public class PlacementView : MonoBehaviour
    {
        [SerializeField] private Transform _cardsContainer;
        [SerializeField] private UnitCardView _cardPrefab;
        [SerializeField] private GameObject _panelRoot;

        private readonly List<UnitCardView> _spawnedCards = new();

        public IEnumerable<UnitCardView> SpawnedCards => _spawnedCards;

        public void SetActive(bool isActive)
        {
            _panelRoot.SetActive(isActive);
        }

        public void CreateCards(List<UnitStatsConfig> configs)
        {
            Clear();

            foreach (var config in configs)
            {
                var card = Instantiate(_cardPrefab, _cardsContainer);
                card.Setup(config);
                _spawnedCards.Add(card);
            }
        }

        private void Clear()
        {
            foreach (var card in _spawnedCards)
            {
                Destroy(card.gameObject);
            }
            _spawnedCards.Clear();
        }
    }
}