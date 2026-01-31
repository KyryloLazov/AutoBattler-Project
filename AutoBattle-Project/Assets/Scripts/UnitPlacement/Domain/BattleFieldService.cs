using Units.Domain;
using UnityEngine;

namespace UnitPlacement.Domain
{
    public class BattleFieldService
    {
        public UnitTeam GetTeamForPosition(Vector3 position)
        {
            return position.x < 0 ? UnitTeam.Blue : UnitTeam.Red;
        }

        public bool IsPositionValid(Vector3 position)
        {
            return true; 
        }
    }
}