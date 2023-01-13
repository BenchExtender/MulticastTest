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
    private readonly IEnemyFactory _enemyFactory;
    private readonly EnemiesCollectionConfig _enemiesCollection;
    private Filter _filter;

    public EnemySpawnSystem(GameConfig config, IEnemyFactory enemyFactory, EnemiesCollectionConfig enemiesCollection)
    {
      _config = config;
      _enemyFactory = enemyFactory;
      _enemiesCollection = enemiesCollection;
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
      _enemyFactory.Create(_enemiesCollection.GetRandom(), GetRandomPosition());
    }

    private Vector3 GetRandomPosition()
    {
      var randomDirection = Random.onUnitSphere;
      randomDirection.y = 0;
      return randomDirection * Random.Range(_config.MinSpawnDistance, _config.MaxSpawnDistance);
    }

    public void Dispose() { }
  }
}