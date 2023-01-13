using Scellecs.Morpeh;
using Zenject;

namespace Codebase.Infrastructure.SystemFactory
{
  public class SystemFactory : ISystemFactory
  {
    private readonly DiContainer _diContainer;

    public SystemFactory(DiContainer diContainer)
    {
      _diContainer = diContainer;
    }

    public ISystem Create<T>() where T : ISystem
    {
      return _diContainer.Resolve<T>();
    }
  }
}