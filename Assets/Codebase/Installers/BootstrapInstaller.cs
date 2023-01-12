using Codebase.Hero.Factory;
using Codebase.Infrastructure.States;
using Codebase.Services.InputService;
using Codebase.Services.SystemFactory;
using Codebase.Services.WorldProvider;
using Codebase.Services.WorldUpdater;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
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
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<WorldProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<WorldUpdater>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<HeroFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemFactory>().AsSingle();
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
