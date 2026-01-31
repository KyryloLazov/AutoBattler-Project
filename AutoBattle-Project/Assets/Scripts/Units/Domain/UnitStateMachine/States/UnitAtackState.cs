using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitAttackState : UnitBaseState
    {
        public UnitAttackState(InitializationUnitStateMachine unitStateMachine, UnitFacade unitFacade, ITargetStrategy targetStrategy) 
            : base(unitStateMachine, unitFacade, targetStrategy) { }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Unit Attack State");
        }

        public override void Update()
        {
            var targetTransform = UnitStateMachine.RuntimeData.Target.Value;

            if (targetTransform == null) return;
            
            UnitFacade.transform.LookAt(targetTransform);

            if (Time.time >= UnitStateMachine.RuntimeData.LastAttackTime + UnitStateMachine.RuntimeData.AttackCooldown)
            {
                Attack(targetTransform);
            }
        }

        private void Attack(Transform targetTransform)
        {
            UnitStateMachine.RuntimeData.LastAttackTime = Time.time;
            
            if (targetTransform.TryGetComponent<UnitFacade>(out var targetFacade))
            {
                float damage = UnitStateMachine.RuntimeData.Damage;
                targetFacade.UnitFsm.RuntimeData.Health.Value -= damage;
                
                Debug.Log($"<color=red>BANG!</color> {UnitFacade.name} hit {targetFacade.name} for {damage} dmg. " +
                          $"HP Left: {targetFacade.UnitFsm.RuntimeData.Health.Value}");
                
                if (targetFacade.UnitFsm.RuntimeData.Health.Value <= 0)
                {
                    Debug.Log($"<color=black>KILL!</color> {targetFacade.name} died!");
                    targetFacade.UnitFsm.RuntimeData.IsDead.Value = true;
                    UnitStateMachine.RuntimeData.Target.Value = null;
                }
            }
        }
    }
}