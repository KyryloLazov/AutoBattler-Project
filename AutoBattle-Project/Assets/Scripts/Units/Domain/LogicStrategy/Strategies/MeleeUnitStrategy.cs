using System;
using System.Collections.Generic;
using Units.Domain.LogicStrategy.Interfaces;
using Units.Domain.TargetStrategy.Interfaces;
using Units.Domain.UnitStateMachine;
using Units.Domain.UnitStateMachine.Handlers;
using Units.Domain.UnitStateMachine.States;
using Units.Presentation;

namespace Units.Domain.LogicStrategy.Strategies
{
    public class MeleeUnitStrategy : IUnitLogicStrategy
    {
        public IState[] CreateStates(InitializationUnitStateMachine fsm, UnitFacade facade, ITargetStrategy targetStrategy)
        {
            return new IState[]
            {
                new UnitIdleState(fsm, facade, targetStrategy),
                new UnitMoveState(fsm, facade, targetStrategy),
                new UnitAttackState(fsm, facade, targetStrategy),
                new UnitDeadState(fsm, facade, targetStrategy, fsm.UnitRegistry)
            };
        }

        public List<IStateHandle> CreateHandlers(InitializationUnitStateMachine fsm, UnitFacade facade)
        {
            return new List<IStateHandle>
            {
                new UnitDeadHandler(fsm),
                new UnitAttackHandler(fsm, facade),
                new UnitMoveHandler(fsm, facade),
                new UnitIdleHandler(fsm)
            };
        }

        public Type GetStartState() => typeof(UnitIdleState);
    }
}