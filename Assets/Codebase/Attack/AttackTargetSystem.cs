using System.Collections.Generic;
using System.Linq;
using Codebase.Enemy;
using Codebase.Hero;
using Codebase.Movement;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Attack
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class AttackTargetSystem : ISystem 
  {
    public World World { get; set; }

    private Filter _enemiesInAttackRange;

    public void OnAwake()
    {
      _enemiesInAttackRange = World.Filter
        .With<Transformable>()
        .With<InAttackRange>()
        .Without<AttackTarget>();
    }

    public void OnUpdate(float deltaTime)
    {
      var groupedEnemies = _enemiesInAttackRange.GroupBy(e => e.GetComponent<InAttackRange>().Attacker);

      foreach (var attackedGroup in groupedEnemies)
      {
        HandleGroup(attackedGroup.Key, attackedGroup.ToList());
      }
    }

    private void HandleGroup(Entity attacker, List<Entity> enemyEntities)
    {
      var hero = attacker.GetComponent<HeroComponent>();
      if (hero.Model.Attack.LastAttackTime + hero.Model.Attack.AttackDelay < Time.time )
      {
        var heroPosition = attacker.GetComponent<Transformable>().Transform.position;
        var targets = SelectAttackTargets(heroPosition, hero.Model.Attack.Range.Value, enemyEntities);

        for (int i = 0; i < hero.Model.Config.AttackTargetsCount && i < targets.Count; i++)
        {
          ref var attackTarget = ref targets[i].AddComponent<AttackTarget>();
          attackTarget.Attacker = attacker;
          attackTarget.Damage = hero.Model.Attack.Damage.Value;
        }

        hero.Model.Attack.LastAttackTime = Time.time;
      }
    }

    private List<Entity> SelectAttackTargets(Vector3 heroPosition, float attackRange, List<Entity> enemyEntities)
    {
      var enemies = enemyEntities.ToDictionary(e => e, e =>
          Vector3.Distance(e.GetComponent<Transformable>().Transform.position, heroPosition))
        .Where(e => e.Value < attackRange)
        .OrderByDescending(e => e.Value)
        .Select(e => e.Key);
      
      return enemies.ToList();
    }

    public void Dispose()
    {
    
    }
  }
}