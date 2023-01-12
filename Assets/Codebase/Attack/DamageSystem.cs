using Codebase.Enemy;
using Codebase.Hero;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Attack
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class DamageSystem : ISystem 
  {
    public World World { get; set; }

    private Filter _filter;

    public void OnAwake()
    {
      _filter = World.Filter
        .With<AttackTarget>()
        .With<Health>()
        .Without<DeadState>();
    }

    public void OnUpdate(float deltaTime)
    {
      foreach (var entity in _filter)
      {
        var target = entity.GetComponent<AttackTarget>();
        ref var health = ref entity.GetComponent<Health>();

        health.DealDamage(target.Damage);
        CheckDeath(health, entity, target);
        Debug.Log(health.Current);
        entity.RemoveComponent<AttackTarget>();
      }
    }

    private static void CheckDeath(Health health, Entity entity, AttackTarget target)
    {
      if (health.Current <= 0)
      {
        entity.AddComponent<DeadState>();
        ref var hero = ref target.Attacker.GetComponent<HeroComponent>(out bool isHero);
        if (isHero)
        {
          hero.Model.KillCount.Value++;
        }
      }
    }

    public void Dispose() { }
  }
}