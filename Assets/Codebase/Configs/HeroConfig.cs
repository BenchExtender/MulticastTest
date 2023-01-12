using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/HeroConfig")]
  public class HeroConfig : ScriptableObject
  {
    [field: SerializeField] public GameObject Prefab { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float SpeedMultiplier { get; set; }
    [field: SerializeField] public float AttackRadius { get; set; }
    [field: SerializeField] public int DamagePerSecond { get; set; }
    [field: SerializeField] public float AttackTargetsCount { get; set; } = 3;
    [field: SerializeField] public float AttackDelay { get; set; } = 1;
  }
}
