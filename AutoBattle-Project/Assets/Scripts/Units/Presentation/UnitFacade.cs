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
    
        [Inject]
        public void Construct(InitializationUnitStateMachine unitFsm, GameContextData gameContext, UnitTeam team,
            TeamColorConfig colorConfig)
        {
            UnitFsm = unitFsm;
            _gameContext = gameContext;
            Team = team;
            _renderer.material = colorConfig.GetMaterial(team);
        }

        private void Start()
        {
            UnitFsm.Initialize(this);
        }

        private void Update()
        {
            if (_gameContext.CurrentPhase.Value != GamePhase.Battle) return;
        
            UnitFsm.Tick();
        }
    }
}