using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitIdleState : UnitBaseState
    {
        public UnitIdleState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade, ITargetStrategy targetStrategy) 
            : base(unitStateMachine, unitFacade, targetStrategy) { }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Unit Idle State");
        }

        public override void Update()
        {
            if (UnitStateMachine.RuntimeData.Target.Value != null) return;
            Transform target = TargetStrategy.FindTarget(UnitFacade);

            if (target != null)
            {
                UnitStateMachine.RuntimeData.Target.Value = target;
            }
        }
    }
}