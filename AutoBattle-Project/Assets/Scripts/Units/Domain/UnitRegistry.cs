using System.Collections.Generic;
using System.Linq;
using UniRx;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain
{
    public class UnitRegistry
    {
        private readonly List<UnitFacade> _allUnits = new();
        
        public IReadOnlyReactiveDictionary<UnitTeam, int> TeamCounts => _teamCounts;
        private readonly ReactiveDictionary<UnitTeam, int> _teamCounts = new();

        public void Register(UnitFacade unit)
        {
            if (!_allUnits.Contains(unit))
            {
                _allUnits.Add(unit);
                ModifyCount(unit.Team, 1);
            }
        }

        public void Unregister(UnitFacade unit)
        {
            if (_allUnits.Remove(unit))
            {
                ModifyCount(unit.Team, -1);
            }
        }

        private void ModifyCount(UnitTeam team, int amount)
        {
            if (!_teamCounts.ContainsKey(team))
            {
                _teamCounts[team] = 0;
            }

            _teamCounts[team] += amount;
        }

        public IEnumerable<UnitFacade> GetUnits(UnitTeam team)
        {
            return _allUnits.Where(u => u.Team == team);
        }

        public void Clear()
        {
            var unitsToDestroy = _allUnits.ToList();
            
            _allUnits.Clear();
            _teamCounts.Clear();

            foreach (var unit in unitsToDestroy)
            {
                if (unit != null && unit.gameObject != null)
                {
                    Object.Destroy(unit.gameObject);
                }
            }
        }
    }
}