using Sirenix.OdinInspector;
using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/HeroConfig")]
  public class HeroConfig : ScriptableObject
  {
    [field: Title("Attributes")]
    [field: SerializeField] public GameObject Prefab { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float SpeedMultiplier { get; set; }
    [field: SerializeField] public float AttackRadius { get; set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public float AttackTargetsCount { get; set; } = 3;
    [field: SerializeField] public float AttackDelay { get; set; } = 1;

    [field: Title("Upgrades")]
    [field: SerializeField] public float SpeedUpgradeStep { get; set; } = 0.5f;
    [field: SerializeField] public int DamageUpgradeStep { get; set; } = 10;
    [field: SerializeField] public float AttackRangeStep { get; set; } = 1f;
    
    [field: SerializeField] public float SpeedUpgradeChance { get; set; } = 60;
    [field: SerializeField] public float DamageUpgradeChance { get; set; } = 30;
    [field: SerializeField] public float AttackRangeChance { get; set; } = 10;
  }
}
