using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/EnemiesCollection")]
  public class EnemiesCollectionConfig : ScriptableObject
  {
    [field: SerializeField] public EnemyConfig[] Enemies { get; set; }
  }
}
