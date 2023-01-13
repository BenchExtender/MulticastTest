using Codebase.Configs;
using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Enemy.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    public Entity Create(EnemyConfig config)
    {
      var enemyObject = Object.Instantiate(config.Prefab);
      var enemyEntity = enemyObject.GetComponent<EnemyComponentProvider>().Entity;
      ref var health = ref enemyEntity.GetComponent<Health>();

      health.Max = config.MaxHealth;
      health.Reset();

      return enemyEntity;
    }
  }
}
