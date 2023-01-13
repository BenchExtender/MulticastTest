using Codebase.UI;
using UnityEngine;

namespace Codebase.Configs
{
  [CreateAssetMenu(menuName = "Configs/GameConfig")]
  public class GameConfig : ScriptableObject
  {
    [field: SerializeField] public int MaxEnemiesCount { get; private set; }
    [field: SerializeField] public float MaxSpawnDistance { get; private set; }
    [field: SerializeField] public float MinSpawnDistance { get; private set; }
    [field: SerializeField] public HudScreen HudPrefab { get; set; }
  }
}
