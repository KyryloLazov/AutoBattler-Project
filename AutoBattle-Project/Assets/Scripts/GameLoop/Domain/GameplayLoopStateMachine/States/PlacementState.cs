using UnitPlacement.Domain;
using UnitPlacement.Presentation;
using UnityEngine;

namespace GameLoop.Domain.GameplayLoopStateMachine.States
{
    public class PlacementState : GameBaseState
    {
        private readonly PlacementModel _model;
        private readonly PlacementPresenter _presenter;

        public PlacementState(GameContextData gameContextData,
            InitializationGameLoopStateMachine gameLoopStateMachine,
            PlacementModel placementModel,
            PlacementPresenter placementPresenter)
            : base(gameContextData, gameLoopStateMachine)
        {
            _model = placementModel;
            _presenter = placementPresenter;
        }

        public override void OnEnter()
        {
            GameContextData.CurrentPhase.Value = GamePhase.Placement;
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