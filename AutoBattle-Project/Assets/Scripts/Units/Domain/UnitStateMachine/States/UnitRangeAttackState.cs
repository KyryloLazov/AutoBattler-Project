using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitRangedAttackState : UnitBaseState
    {
        public UnitRangedAttackState(InitializationUnitStateMachine sm, UnitFacade facade, ITargetStrategy strategy) 
            : base(sm, facade, strategy) { }

        public override void Update()
        {
            var targetTransform = UnitStateMachine.RuntimeData.Target.Value;
            if (targetTransform == null) return;

            UnitFacade.transform.LookAt(targetTransform);

            if (Time.time >= UnitStateMachine.RuntimeData.LastAttackTime + UnitStateMachine.RuntimeData.AttackCooldown)
            {
                Shoot(targetTransform);
            }
        }

        private void Shoot(Transform targetTransform)
        {
            UnitStateMachine.RuntimeData.LastAttackTime = Time.time;
            
            // SpawnProjectile(start, end)
            Debug.Log($"<color=cyan>SHOOT!</color> {UnitFacade.name} fired at {targetTransform.name}");
            
            Debug.DrawLine(UnitFacade.transform.position, targetTransform.position, Color.cyan, 0.2f);

            if (targetTransform.TryGetComponent<UnitFacade>(out var targetFacade))
            {
                targetFacade.UnitFsm.RuntimeData.Health.Value -= UnitStateMachine.RuntimeData.Damage;
                
                if (targetFacade.UnitFsm.RuntimeData.Health.Value <= 0)
                {
                    targetFacade.UnitFsm.RuntimeData.IsDead.Value = true;
                    UnitStateMachine.RuntimeData.Target.Value = null;
                }
            }
        }
    }
}