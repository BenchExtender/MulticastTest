using Codebase.Attack;
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
    
    public Entity Create()
    {
      var heroObject = Object.Instantiate(_heroConfig.Prefab);
      var provider = heroObject.GetComponent<HeroComponentProvider>();
      var attackRange = heroObject.GetComponent<AttackRange>();
      var heroEntity = provider.Entity;
      var attackModel = new AttackModel(_heroConfig.Damage, _heroConfig.AttackRadius, _heroConfig.AttackDelay);
      var heroModel = new HeroModel(_heroConfig.Speed, attackModel, _heroConfig);
      
      heroEntity.AddComponent<MovementVelocity>();
      ref var hero = ref heroEntity.GetComponent<HeroComponent>();
      
      hero.Model = heroModel;

      attackRange.Init(heroEntity, heroModel);

      return heroEntity;
    }
  }
}