using Codebase.Configs;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
  public class ConfigsInstaller : MonoInstaller
  {
    [field: SerializeField] private HeroConfig HeroConfig { get; set; }

    public override void InstallBindings()
    {
      Container.Bind<HeroConfig>().FromInstance(HeroConfig);
    }
  }
}
