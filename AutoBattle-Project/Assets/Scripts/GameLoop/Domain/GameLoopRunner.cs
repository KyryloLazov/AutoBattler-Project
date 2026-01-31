using GameLoop.Domain.GameplayLoopStateMachine;
using Zenject;

namespace GameLoop.Domain
{
    public class GameLoopRunner : ITickable
    {
        private readonly InitializationGameLoopStateMachine _fsmFacade;
        private readonly StateHandleChain _handleChain;

        public GameLoopRunner(
            InitializationGameLoopStateMachine fsmFacade, 
            StateHandleChain handleChain)
        {
            _fsmFacade = fsmFacade;
            _handleChain = handleChain;
        }

        public void Tick()
        {
            if (_fsmFacade.StateMachine == null) return;
            
            _handleChain.HandleState();
            
            if (_fsmFacade.StateMachine.isUpdate && _fsmFacade.StateMachine.currentStates != null)
            {
                _fsmFacade.StateMachine.currentStates.Update();
            }
        }
    }
}