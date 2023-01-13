using Scellecs.Morpeh;

namespace Codebase.Infrastructure.SystemFactory
{
  public interface ISystemFactory
  {
    public ISystem Create<T>() where T : ISystem;
  }
}
