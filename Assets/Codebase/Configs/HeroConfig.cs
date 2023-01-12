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
    [field: SerializeField] public float DamagePerSecond { get; set; }
  }
}
