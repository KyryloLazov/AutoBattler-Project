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
        public override void InstallBindings()
        {
            BindInstance(_gameHudView);
            BindNewInstance<GameHudPresenter>();
            BindNewInstance<GameContextData>();
            BindNewInstance<StateHandleChain>();
            BindNewInstance<PlacementStateHandler>();
            BindNewInstance<BattleStateHandler>();
            BindNewInstance<ResultStateHandler>();
            BindNewInstance<InitializationGameLoopStateMachine>();
            BindNewInstance<GameLoopRunner>();
        }
    }
}