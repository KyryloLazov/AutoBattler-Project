using Units.Domain.TargetStrategy.Interfaces;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.States
{
    public class UnitHealState : UnitBaseState
    {
        public UnitHealState(InitializationUnitStateMachine sm, UnitFacade facade, ITargetStrategy strategy) 
            : base(sm, facade, strategy) { }

        public override void Update()
        {
            var targetTransform = UnitStateMachine.RuntimeData.Target.Value;
            if (targetTransform == null) return;

            UnitFacade.transform.LookAt(targetTransform);

            if (Time.time >= UnitStateMachine.RuntimeData.LastAttackTime + UnitStateMachine.RuntimeData.AttackCooldown)
            {
                Heal(targetTransform);
            }
        }

        private void Heal(Transform targetTransform)
        {
            UnitStateMachine.RuntimeData.LastAttackTime = Time.time;
            
            if (targetTransform.TryGetComponent<UnitFacade>(out var targetFacade))
            {
                float healAmount = UnitStateMachine.RuntimeData.Damage;
                targetFacade.UnitFsm.RuntimeData.Health.Value += healAmount;
                
                Debug.Log($"<color=green>HEAL!</color> {UnitFacade.name} healed {targetFacade.name} for {healAmount}");
                
                if (targetFacade.UnitFsm.RuntimeData.Health.Value >= targetFacade.UnitFsm.RuntimeData.MaxHp) 
                {
                    UnitStateMachine.RuntimeData.Target.Value = null;
                }
            }
        }
    }
}