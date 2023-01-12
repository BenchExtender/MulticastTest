using Scellecs.Morpeh;
using Zenject;

namespace Codebase.Services.WorldUpdater
{
  public interface IWorldUpdater : ITickable, IFixedTickable, ILateTickable
  {
    void Setup(World world);
  }
}