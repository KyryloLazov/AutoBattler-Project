using GameLoop.Domain.GameplayLoopStateMachine.States;
using UnitPlacement.Domain;
using UnitPlacement.Presentation;

namespace GameLoop.Domain.GameplayLoopStateMachine
{
    public class InitializationGameLoopStateMachine
    {
        public StateMachine StateMachine { get; private set; }
        public GameContextData ContextData { get; private set; }

        private PlacementState _placementState;
        private BattleState _battleState;
        private ResultState _resultState;
        private PlacementModel _placementModel;
        private PlacementPresenter _placementPresenter;

        public InitializationGameLoopStateMachine(
            GameContextData contextData,
            PlacementPresenter placementPresenter,
            PlacementModel placementModel)
        {
            ContextData = contextData;
            _placementPresenter = placementPresenter;
            _placementModel = placementModel;

            Initialize();
        }

        private void Initialize()
        {
            _battleState = new BattleState(ContextData, this);
            _placementState = new PlacementState(ContextData, this, _placementModel, _placementPresenter);
            _resultState = new ResultState(ContextData, this);
            
            StateMachine = new StateMachine(_placementState, _battleState, _resultState);
            StateMachine.SwitchStates<PlacementState>();
        }
    }
}