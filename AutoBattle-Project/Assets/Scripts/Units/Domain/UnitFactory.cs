using Units.Domain.LogicStrategy.Interfaces;
using Units.Domain.TargetStrategy.Interfaces;
using Units.Domain.UnitStateMachine;
using Units.Infrastructure.Config;
using Units.Presentation;
using Zenject;

namespace Units.Domain
{
    public class UnitFactory : IFactory<UnitStatsConfig, UnitTeam, UnitFacade>
    {
        private readonly DiContainer _container;
        private readonly UnitRegistry _registry;

        public UnitFactory(DiContainer container, UnitRegistry registry)
        {
            _container = container;
            _registry = registry;
        }

        public UnitFacade Create(UnitStatsConfig config, UnitTeam team)
        {
            var subContainer = _container.CreateSubContainer();

            subContainer.BindInstance(config);
            subContainer.BindInstance(team);
            subContainer.Bind<UnitRuntimeData>().AsSingle();
            
            IUnitLogicStrategy logicStrategy = config.LogicScheme.GetStrategy();
            subContainer.Bind<IUnitLogicStrategy>().FromInstance(logicStrategy);
            
            ITargetStrategy targetStrategy = config.TargetingScheme.CreateStrategy(_registry);
            subContainer.Bind<ITargetStrategy>().FromInstance(targetStrategy);
            
            subContainer.Bind<InitializationUnitStateMachine>().AsSingle();

            UnitFacade instance = subContainer.InstantiatePrefabForComponent<UnitFacade>(config.Prefab);
            subContainer.Bind<UnitFacade>().FromInstance(instance);
            
            _registry.Register(instance);
            return instance;
        }
    }
}