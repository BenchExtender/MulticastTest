using Codebase.Configs;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
  public class ConfigsInstaller : MonoInstaller
  {
    [field: SerializeField] private HeroConfig HeroConfig { get; set; }
    [field: SerializeField] private EnemiesCollectionConfig EnemiesCollection { get; set; }
    [field: SerializeField] private GameConfig GameConfig { get; set; }

    public override void InstallBindings()
    {
      Container.Bind<HeroConfig>().FromInstance(HeroConfig);
      Container.Bind<EnemiesCollectionConfig>().FromInstance(EnemiesCollection);
      Container.Bind<GameConfig>().FromInstance(GameConfig);
    }
  }
}
