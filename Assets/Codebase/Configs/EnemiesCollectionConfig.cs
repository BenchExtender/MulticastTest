using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/EnemiesCollection")]
  public class EnemiesCollectionConfig : ScriptableObject
  {
    [field: SerializeField] public EnemyConfig[] Enemies { get; set; }

    public EnemyConfig GetRandom()
    {
      return Enemies[Random.Range(0, Enemies.Length)];
    }
  }
}
