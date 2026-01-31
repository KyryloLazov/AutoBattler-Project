using Units.Domain.LogicStrategy.Schemes;
using Units.Domain.TargetStrategy.Schemes;
using Units.Presentation;
using UnityEngine;

namespace Units.Infrastructure.Config
{
    [CreateAssetMenu(menuName = "Configs/UnitStats")]
    public class UnitStatsConfig : ScriptableObject
    {
        [field: SerializeField] public string UnitName { get; private set; }
        [field: SerializeField]  public Sprite Icon { get; private set; }
        [field: SerializeField] public UnitLogicScheme LogicScheme { get; private set; }
        [field: SerializeField] public TargetingScheme TargetingScheme { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackCooldown { get; private set; }
        [field: SerializeField] public UnitFacade Prefab { get; private set; }
    }
}