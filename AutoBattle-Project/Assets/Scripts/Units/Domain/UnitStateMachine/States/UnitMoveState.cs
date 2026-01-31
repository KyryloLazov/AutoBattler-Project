using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitMoveState : UnitBaseState
    {
        public UnitMoveState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade, ITargetStrategy targetStrategy)
            : base(unitStateMachine, unitFacade, targetStrategy) { }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Unit Move State");
        }
        
        public override void Update()
        {
            var target = UnitStateMachine.RuntimeData.Target.Value;
            if (target != null)
            {
                var dir = (target.position - UnitFacade.transform.position).normalized;
                UnitFacade.transform.position += dir * (UnitStateMachine.RuntimeData.MoveSpeed * Time.deltaTime);
                UnitFacade.transform.LookAt(target);
            }
        }
    }
}