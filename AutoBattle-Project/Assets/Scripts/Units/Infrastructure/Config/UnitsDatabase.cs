namespace Units.Infrastructure.Config
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Configs/UnitsDatabase")]
    public class UnitsDatabase : ScriptableObject
    {
        [field: SerializeField]public List<UnitStatsConfig> AvailableUnits { get; private set; }
    }
}