using Zenject;

namespace Codebase.Infrastructure.States
{
  public class StateFactory : IStateFactory
  {
    private readonly DiContainer _container;

    public StateFactory(DiContainer container)
    {
      _container = container;
    }

    public IExitableState Create<T>() where T : IExitableState
    {
      return _container.Resolve<T>();
    }
  }
}
