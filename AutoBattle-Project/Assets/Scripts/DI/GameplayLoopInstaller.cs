using BattlePhase;
using GameLoop.Domain;
using GameLoop.Domain.GameplayLoopStateMachine;
using GameLoop.Domain.GameplayLoopStateMachine.Handlers;
using GameLoop.Presentation;
using UnityEngine;
using UnityEngine.Serialization;

namespace DI
{
    public class GameplayLoopInstaller : BaseBindings
    {
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private ResultView _resultView;
        public override void InstallBindings()
        {
            BindInstance(_gameHudView);
            BindInstance(_resultView);
            
            BindNewInstance<GameHudPresenter>();
            BindNewInstance<ResultPresenter>();
            
            BindNewInstance<GameContextData>();
            BindNewInstance<StateHandleChain>();
            BindNewInstance<PlacementStateHandler>();
            BindNewInstance<BattleStateHandler>();
            BindNewInstance<ResultStateHandler>();
            BindNewInstance<InitializationGameLoopStateMachine>();
            
            BindNewInstance<GameLoopRunner>();
            BindNewInstance<BattleService>();
        }
    }
}