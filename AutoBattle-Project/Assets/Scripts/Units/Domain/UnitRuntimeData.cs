using UniRx;
using Units.Infrastructure.Config;
using UnityEngine;

namespace Units.Domain
{
    public class UnitRuntimeData
    {
        public ReactiveProperty<float> Health;
        public ReactiveProperty<bool> IsDead;
        public ReactiveProperty<Transform> Target;
    
        public float AttackRange;
        public float MoveSpeed;
        public float Damage;
        public float AttackCooldown;
        public float LastAttackTime;
    
        public UnitRuntimeData(UnitStatsConfig config)
        {
            Health = new ReactiveProperty<float>(config.Health);
            IsDead = new ReactiveProperty<bool>(false);
            Target = new ReactiveProperty<Transform>(null);
        
            AttackRange = config.AttackRange;
            MoveSpeed = config.MoveSpeed;
            Damage = config.Damage;
            AttackCooldown = config.AttackCooldown;
            LastAttackTime = 0;
        }
    }
}