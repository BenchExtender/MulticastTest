using Codebase.Attack.Effect;
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

        if (health.Current <= 0)
          ApplyDeadState(entity, target);
        else
          ApplyDamaged(entity, target);
        
        entity.RemoveComponent<AttackTarget>();
      }
    }

    private void ApplyDeadState(Entity entity, AttackTarget target)
    {
      ref var deadState = ref entity.AddComponent<DeadState>();
      deadState.Killer = target.Attacker;
    }

    private void ApplyDamaged(Entity entity, AttackTarget target)
    {
      ref var damaged = ref entity.AddComponent<DamagedState>();
      damaged.Damage = target.Damage;
      damaged.Dealer = target.Attacker;
    }

    public void Dispose() { }
  }
}