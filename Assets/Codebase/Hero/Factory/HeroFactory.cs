using Codebase.Configs;
using Codebase.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly HeroConfig _heroConfig;

    public HeroFactory(HeroConfig heroConfig)
    {
      _heroConfig = heroConfig;
    }
    
    public GameObject Create()
    {
      var heroObject = Object.Instantiate(_heroConfig.Prefab);
      var provider = heroObject.GetComponent<HeroComponentProvider>();
      var heroEntity = provider.Entity;
      var heroModel = new HeroModel(_heroConfig.Speed, _heroConfig.DamagePerSecond, _heroConfig.AttackRadius,
        _heroConfig);
      
      heroEntity.AddComponent<MovementVelocity>();
      ref var hero = ref heroEntity.GetComponent<HeroComponent>();

      return heroObject;
    }
  }
}