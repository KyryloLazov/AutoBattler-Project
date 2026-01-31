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
    public class HealerUnitStrategy : IUnitLogicStrategy
    {
        public IState[] CreateStates(InitializationUnitStateMachine fsm, UnitFacade facade, ITargetStrategy strategy)
        {
            return new IState[]
            {
                new UnitIdleState(fsm, facade, strategy),
                new UnitMoveState(fsm, facade, strategy),
                new UnitHealState(fsm, facade, strategy),
                new UnitDeadState(fsm, facade, strategy, fsm.UnitRegistry)
            };
        }

        public List<IStateHandle> CreateHandlers(InitializationUnitStateMachine fsm, UnitFacade facade)
        {
            return new List<IStateHandle>
            {
                new UnitDeadHandler(fsm),
                new UnitHealHandler(fsm, facade),
                new UnitMoveHandler(fsm, facade),
                new UnitIdleHandler(fsm)
            };
        }

        public Type GetStartState() => typeof(UnitIdleState);
    }
}