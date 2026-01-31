using System;
using System.Collections.Generic;
using Units.Domain.TargetStrategy.Interfaces;
using Units.Domain.UnitStateMachine;
using Units.Presentation;

namespace Units.Domain.LogicStrategy.Interfaces
{
    public interface IUnitLogicStrategy
    {
        IState[] CreateStates(InitializationUnitStateMachine fsm, UnitFacade facade, ITargetStrategy strategy);
        List<IStateHandle> CreateHandlers(InitializationUnitStateMachine fsm, UnitFacade facade);
        Type GetStartState();
    }
}