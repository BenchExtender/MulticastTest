using Codebase.Configs;
using UnityEngine;

namespace Codebase.Enemy.Factory
{
  public interface IEnemyFactory
  {
    GameObject Create(EnemyConfig config);
  }
}
