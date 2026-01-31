using System.Collections.Generic;
using System.Linq;
using Units.Presentation;

namespace Units.Domain
{
    public class UnitRegistry
    {
        private readonly List<UnitFacade> _allUnits = new();

        public void Register(UnitFacade unit)
        {
            if (!_allUnits.Contains(unit))
            {
                _allUnits.Add(unit);
            }
        }

        public void Unregister(UnitFacade unit)
        {
            _allUnits.Remove(unit);
        }

        public IEnumerable<UnitFacade> GetUnits(UnitTeam team)
        {
            return _allUnits.Where(u => u.Team == team && !u.UnitFsm.RuntimeData.IsDead.Value);
        }
    }
}