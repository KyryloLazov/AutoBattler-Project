using GameLoop.Domain.GameplayLoopStateMachine;
using GameLoop.Domain.GameplayLoopStateMachine.Handlers;

namespace DI
{
    public class GameplayLoopInstaller : BaseBindings
    {
        public override void InstallBindings()
        {
            BindNewInstance<GameContextData>();
            BindNewInstance<StateHandleChain>();
            BindNewInstance<PlacementStateHandler>();
            BindNewInstance<BattleStateHandler>();
            BindNewInstance<ResultStateHandler>();
            BindNewInstance<InitializationGameLoopStateMachine>();
        }
    }
}