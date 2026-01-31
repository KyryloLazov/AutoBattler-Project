using System;
using UniRx;
using UnitPlacement.Domain;
using Units.Infrastructure.Config;
using Zenject;

namespace UnitPlacement.Presentation
{
    public class PlacementPresenter : IInitializable, IDisposable
    {
        private readonly PlacementView _view;
        private readonly UnitsDatabase _database;
        private readonly PlacementModel _placementModel;
        private readonly CompositeDisposable _disposables = new();

        public PlacementPresenter(
            PlacementView view,
            UnitsDatabase database,
            PlacementModel placementModel)
        {
            _view = view;
            _database = database;
            _placementModel = placementModel;
        }

        public void Initialize()
        {
            _view.CreateCards(_database.AvailableUnits);

            foreach (var card in _view.SpawnedCards)
            {
                card.OnClick
                    .Subscribe(_ => OnCardClicked(card.Config))
                    .AddTo(_disposables);
            }

            _placementModel.SelectedUnitConfig
                .Subscribe(UpdateVisualSelection)
                .AddTo(_disposables);
        }

        public void SetViewVisibility(bool isVisible)
        {
            _view.SetActive(isVisible);
        }

        private void OnCardClicked(UnitStatsConfig config)
        {
            _placementModel.SelectedUnitConfig.Value = config;
        }

        private void UpdateVisualSelection(UnitStatsConfig selectedConfig)
        {
            foreach (var card in _view.SpawnedCards)
            {
                card.SetSelected(card.Config == selectedConfig);
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}