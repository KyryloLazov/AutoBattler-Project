using System;
using GameLoop.Domain.GameplayLoopStateMachine;
using UnitPlacement.Infrastructure.Config;
using Units.Domain;
using Units.Domain.UnitStateMachine;
using UnityEngine;
using Zenject;

namespace Units.Presentation
{
    public class UnitFacade : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        public UnitTeam Team { get; private set; }
        public InitializationUnitStateMachine UnitFsm  { get; private set; }
        private GameContextData _gameContext; 
        private DiContainer _subContainer;
    
        [Inject]
        public void Construct(InitializationUnitStateMachine unitFsm, GameContextData gameContext, UnitTeam team,
            TeamColorConfig colorConfig, DiContainer subContainer)
        {
            UnitFsm = unitFsm;
            _gameContext = gameContext;
            Team = team;
            _subContainer = subContainer;
            _renderer.material = colorConfig.GetMaterial(team);
        }

        private void Start()
        {
            UnitFsm.Initialize(this);
        }

        private void Update()
        {
            if (_gameContext.IsBattleRequested.Value == false) return; 
        
            UnitFsm.Tick();
        }
    }
}