using Codebase.Hero.Factory;
using Codebase.Services.SceneLoader;
using Codebase.Services.WorldUpdater;
using Scellecs.Morpeh;

namespace Codebase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public void Enter()
    {
      _sceneLoader.Load(Scenes.Gameplay.ToString(), InitializeSimulation);
    }

    private void InitializeSimulation()
    {
      _gameStateMachine.Enter<InitSimulationState>();
    }

    public void Exit() { }
  }
}
