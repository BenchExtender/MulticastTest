using Codebase.Attack;
using Codebase.Configs;
using Codebase.Enemy;
using Codebase.Hero;
using Codebase.Hero.Factory;
using Codebase.Movement;
using Codebase.Services.SystemFactory;
using Codebase.Services.WorldProvider;
using Codebase.Services.WorldUpdater;
using Codebase.UI;
using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Infrastructure.States
{
    public class InitSimulationState : IState
    {
        private readonly IWorldProvider _worldProvider;
        private readonly IWorldUpdater _worldUpdater;
        private readonly ISystemFactory _systemFactory;
        private readonly IHeroFactory _heroFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IHudFactory _hudFactory;
        private readonly GameConfig _gameConfig;
        private SystemsGroup _systemGroup;
        private World _world;

        public InitSimulationState(IWorldProvider worldProvider, IWorldUpdater worldUpdater, ISystemFactory systemFactory, 
            IHeroFactory heroFactory, GameStateMachine gameStateMachine, IHudFactory hudFactory)
        {
            _worldProvider = worldProvider;
            _worldUpdater = worldUpdater;
            _systemFactory = systemFactory;
            _heroFactory = heroFactory;
            _gameStateMachine = gameStateMachine;
            _hudFactory = hudFactory;
        }
    
        public void Enter()
        {
            InitializeWorld();
            CreateSystems();
      
            _systemGroup.Initialize();

            var heroEntity = _heroFactory.Create();

            CreateHud(heroEntity);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CreateSystems()
        {
            _systemGroup = _world.CreateSystemsGroup();
            _systemGroup.AddSystem(_systemFactory.Create<HeroMovementSystem>());
            _systemGroup.AddSystem(_systemFactory.Create<MovementSystem>());
            _systemGroup.AddSystem(_systemFactory.Create<EnemySpawnSystem>());
            _systemGroup.AddSystem(_systemFactory.Create<EnemyDisposeSystem>());
            _systemGroup.AddSystem(_systemFactory.Create<AttackTargetSystem>());
            _systemGroup.AddSystem(_systemFactory.Create<DamageSystem>());
            _world.AddSystemsGroup(0, _systemGroup);
        }

        private void InitializeWorld()
        {
            _world = World.Default;
            _worldProvider.World = _world;
            _worldUpdater.Setup(_world);
        }

        private void CreateHud(Entity heroEntity)
        {
            var heroModel = heroEntity.GetComponent<HeroComponent>().Model;
            var hud = _hudFactory.Create();
            hud.Init(heroModel);
        }

        public void Exit()
        {
    
        }
    }
}
