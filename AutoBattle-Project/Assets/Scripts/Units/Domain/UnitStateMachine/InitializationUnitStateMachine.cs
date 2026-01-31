using Units.Domain.LogicStrategy.Interfaces;
using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;

namespace Units.Domain.UnitStateMachine
{
    public class InitializationUnitStateMachine
    {
        public StateMachine StateMachine { get; private set; }
        public StateHandleChain HandleChain { get; private set; }
        public UnitRuntimeData RuntimeData { get; private set; }
        
        private readonly IUnitLogicStrategy _logicStrategy;
        private readonly ITargetStrategy _targetStrategy;

        public InitializationUnitStateMachine(
            UnitRuntimeData runtimeData,
            IUnitLogicStrategy logicStrategy,
            ITargetStrategy targetStrategy)
        {
            RuntimeData = runtimeData;
            _logicStrategy = logicStrategy;
            _targetStrategy = targetStrategy;
        }

        public void Initialize(UnitFacade facade) 
        {
            var states = _logicStrategy.CreateStates(this, facade, _targetStrategy);
            StateMachine = new StateMachine(states);

            var handlers = _logicStrategy.CreateHandlers(this, facade);
            HandleChain = new StateHandleChain(handlers);

            var startType = _logicStrategy.GetStartState();
            StateMachine.SwitchState(startType);
        }

        public void Tick()
        {
            if (StateMachine == null) return;
        
            HandleChain.HandleState();
        
            if (StateMachine.isUpdate && StateMachine.currentStates != null)
            {
                StateMachine.currentStates.Update();
            }
        }
    }
}