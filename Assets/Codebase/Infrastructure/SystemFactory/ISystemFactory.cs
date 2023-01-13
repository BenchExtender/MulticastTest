using Scellecs.Morpeh;

namespace Codebase.Services.SystemFactory
{
  public interface ISystemFactory
  {
    public ISystem Create<T>() where T : ISystem;
  }
}
