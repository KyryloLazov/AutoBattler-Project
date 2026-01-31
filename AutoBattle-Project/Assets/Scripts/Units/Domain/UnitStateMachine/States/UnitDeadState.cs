using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitDeadState : UnitBaseState
    {
        private UnitRegistry _unitRegistry;

        public UnitDeadState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade,
            ITargetStrategy targetStrategy, UnitRegistry unitRegistry)
            : base(unitStateMachine, unitFacade, targetStrategy)
        {
            _unitRegistry = unitRegistry;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            _unitRegistry.Unregister(UnitFacade);
            
            UnitFacade.gameObject.SetActive(false); 
            
            UnitStateMachine.RuntimeData.IsDead.Value = true; 
        }
    }
}