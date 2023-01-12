using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/Enemy")]
  public class EnemyConfig : ScriptableObject
  {
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
  }
}
