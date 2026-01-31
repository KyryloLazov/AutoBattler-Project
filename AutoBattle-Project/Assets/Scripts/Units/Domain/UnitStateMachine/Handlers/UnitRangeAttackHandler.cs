using Units.Domain.UnitStateMachine.States;
using Units.Presentation;
using UnityEngine;

namespace Units.Domain.UnitStateMachine.Handlers
{
    public class UnitRangedAttackHandler : IStateHandle
    {
        private readonly InitializationUnitStateMachine _fsm;
        private readonly UnitFacade _facade;

        public UnitRangedAttackHandler(InitializationUnitStateMachine fsm, UnitFacade facade)
        {
            _fsm = fsm;
            _facade = facade;
        }

        public bool CanHandle()
        {
            var target = _fsm.RuntimeData.Target.Value;
            if (target == null) return false;

            float distance = Vector3.Distance(_facade.transform.position, target.position);
            return distance <= _fsm.RuntimeData.AttackRange;
        }

        public void Handle()
        {
            _fsm.StateMachine.SwitchStates<UnitRangedAttackState>();
        }
    }
}