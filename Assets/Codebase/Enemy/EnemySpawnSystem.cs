using System.Linq;
using Codebase.Configs;
using Codebase.Enemy.Factory;
using Codebase.Movement;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Enemy
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class EnemySpawnSystem : ISystem 
  {
    public World World { get; set; }

    private readonly GameConfig _config;
    private readonly EnemiesCollectionConfig _enemiesCollection;
    private readonly IEnemyFactory _enemyFactory;
    private Filter _filter;

    public EnemySpawnSystem(GameConfig config, EnemiesCollectionConfig enemiesCollection, IEnemyFactory enemyFactory)
    {
      _config = config;
      _enemiesCollection = enemiesCollection;
      _enemyFactory = enemyFactory;
    }

    public void OnAwake()
    {
      _filter = World.Filter.With<EnemyComponent>();
    }

    public void OnUpdate(float deltaTime)
    {
      if (_filter.Count() < _config.MaxEnemiesCount)
      {
        SpawnEnemy();
      }
    }

    private void SpawnEnemy()
    {
      EnemyConfig enemyConfig = SelectEnemyToSpawn();
      var enemyEntity = _enemyFactory.Create(enemyConfig);
      enemyEntity.GetComponent<Transformable>().Transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
      var randomDirection = Random.onUnitSphere;
      randomDirection.y = 0;
      return randomDirection * Random.Range(_config.MinSpawnDistance, _config.MaxSpawnDistance);
    }

    private EnemyConfig SelectEnemyToSpawn()
    {
      return _enemiesCollection.GetRandom();
    }

    public void Dispose()
    {
    
    }
  }
}