using Codebase.Configs;
using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Enemy.Factory
{
  public interface IEnemyFactory
  {
    Entity Create(EnemyConfig config, Vector3 position);
  }
}
