using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Services.WorldUpdater
{
  public class WorldUpdater : IWorldUpdater
  {
    private World _world;

    public void Setup(World world)
    {
      _world = world;
      _world.UpdateByUnity = false;
    }

    public void Tick()
    {
      _world?.Update(Time.deltaTime);
    }

    public void FixedTick()
    {
      _world?.FixedUpdate(Time.deltaTime);
    }

    public void LateTick()
    {
      _world?.LateUpdate(Time.deltaTime);
    }
  }
}