using Codebase.Enemy.Factory;
using Codebase.Hero.Factory;
using Codebase.Infrastructure.States;
using Codebase.Infrastructure.SystemFactory;
using Codebase.Services.CoroutineRunner;
using Codebase.Services.HeroUpgradeService;
using Codebase.Services.InputService;
using Codebase.Services.RandomService;
using Codebase.Services.SceneLoader;
using Codebase.Services.WorldUpdater;
using Codebase.UI;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        private GameStateMachine _gameStateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            _gameStateMachine = gameStateMachine;
        }
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            BindServices();
            BindFactories();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<WorldUpdater>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroUpgradeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<HeroFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HudFactory>().AsSingle();
        }

        public void Initialize()
        {
            _gameStateMachine.Add<BootstrapState>(_stateFactory.Create<BootstrapState>());
            _gameStateMachine.Add<InitSimulationState>(_stateFactory.Create<InitSimulationState>());
            _gameStateMachine.Add<GameLoopState>(_stateFactory.Create<GameLoopState>());
            
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
