using UnitPlacement.Domain;
using UnitPlacement.Presentation;
using Units.Domain;
using UnityEngine;

namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class PlacementState : GameBaseState
    {
        private readonly PlacementModel _model;
        private readonly PlacementPresenter _presenter;
        private readonly UnitRegistry _registry;

        public PlacementState(GameContextData gameContextData,
            InitializationGameLoopStateMachine gameLoopStateMachine,
            PlacementModel placementModel,
            PlacementPresenter placementPresenter,
            UnitRegistry registry)
            : base(gameContextData, gameLoopStateMachine)
        {
            _model = placementModel;
            _presenter = placementPresenter;
            _registry = registry;
        }

        public override void OnEnter()
        {
            GameContextData.CurrentPhase.Value = GamePhase.Placement;
            _registry.Clear();
            _presenter.SetViewVisibility(true);
            Debug.Log("Enter Placement State");
        }

        public override void OnExit()
        {
            _presenter.SetViewVisibility(false);
            _model.SelectedUnitConfig.Value = null;
        }
        public override void Update() { }
        public override void FixedUpdate() { }
    }
}