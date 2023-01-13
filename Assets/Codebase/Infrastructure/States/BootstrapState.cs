using Codebase.Hero.Factory;
using Codebase.Services.SystemFactory;
using Codebase.Services.WorldUpdater;
using Scellecs.Morpeh;

namespace Codebase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private GameStateMachine _gameStateMachine;

    public BootstrapState(GameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }
    
    public void Enter()
    {
      _gameStateMachine.Enter<InitSimulationState>();
    }

    public void Exit()
    {
      
    }
  }
}
