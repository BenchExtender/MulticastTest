using Sirenix.OdinInspector;
using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/HeroConfig")]
  public class HeroConfig : ScriptableObject
  {
    [field: Title("Attributes")]
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float SpeedMultiplier { get; private set; }
    [field: SerializeField] public float AttackRadius { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float AttackTargetsCount { get; private set; } = 3;
    [field: SerializeField] public float AttackDelay { get; private set; } = 1;

    [field: Title("Upgrades")]
    [field: SerializeField] public float SpeedUpgradeStep { get; private set; } = 0.5f;
    [field: SerializeField] public int DamageUpgradeStep { get; private set; } = 10;
    [field: SerializeField] public float AttackRangeStep { get; private set; } = 1f;
    
    [field: SerializeField] public int SpeedUpgradeChance { get; private set; } = 60;
    [field: SerializeField] public int DamageUpgradeChance { get; private set; } = 30;
    [field: SerializeField] public int AttackRangeChance { get; private set; } = 10;
  }
}
