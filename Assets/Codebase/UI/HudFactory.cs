using Codebase.Configs;
using Codebase.Hero;
using Zenject;

namespace Codebase.UI
{
  public class HudFactory : IHudFactory
  {
    private GameConfig _gameConfig;
    private DiContainer _diContainer;

    public HudFactory(GameConfig gameConfig, DiContainer diContainer)
    {
      _gameConfig = gameConfig;
      _diContainer = diContainer;
    }

    public HudScreen Create(HeroModel heroModel)
    {
      var hud =  _diContainer.InstantiatePrefabForComponent<HudScreen>(_gameConfig.HudPrefab);
      hud.Init(heroModel);
      return hud;
    }
  }
}