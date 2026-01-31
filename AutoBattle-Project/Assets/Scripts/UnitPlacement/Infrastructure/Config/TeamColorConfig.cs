using Units.Domain;
using UnityEngine;

namespace UnitPlacement.Infrastructure.Config
{
    [CreateAssetMenu(menuName = "Configs/TeamColors")]
    public class TeamColorConfig : ScriptableObject
    {
        [field: SerializeField] public Material BlueTeamMaterial { get; private set; }
        [field: SerializeField] public Material RedTeamMaterial { get; private set; }

        public Material GetMaterial(UnitTeam team)
        {
            return team == UnitTeam.Blue ? BlueTeamMaterial : RedTeamMaterial;
        }
    }
}