using Codebase.Attack;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Hero
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public sealed class KillCountSystem : ISystem 
  {
    public World World { get; set; }

    private Filter _filter;

    public void OnAwake()
    {
      _filter = World.Filter.With<DeadState>();
    }

    public void OnUpdate(float deltaTime)
    {
      foreach (var entity in _filter)
      {
        var deadState = entity.GetComponent<DeadState>();
        UpdateKillCount(deadState.Killer);
      }
    }
    
    private void UpdateKillCount(Entity killer)
    {
      ref var hero = ref killer.GetComponent<HeroComponent>(out bool isHero);
      if (isHero)
      {
        hero.Model.KillCount.Value++;
      }
    }

    public void Dispose() { }
  }
}