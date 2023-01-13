using Codebase.Configs;
using Codebase.Hero;
using Codebase.Services.RandomService;
using UnityEngine;

namespace Codebase.Services.HeroUpgradeService
{
  public class HeroUpgradeService : IHeroUpgradeService
  {
    private readonly IRandomService _randomService;

    public HeroUpgradeService(IRandomService randomService)
    {
      _randomService = randomService;
    }
    
    public void UpgradeRandom(HeroModel heroModel)
    {
      int randomValue = _randomService.Range(1, 101);
      int current = 0;
      HeroConfig config = heroModel.Config;

      if (randomValue >= current && randomValue <= config.AttackRangeChance)
      {
        UpgradeAttackRange(heroModel);
        return;
      }

      current += config.AttackRangeChance;

      if (randomValue > current && randomValue <= current + config.DamageUpgradeChance)
      {
        UpgradeDamage(heroModel);
        return;
      } 
      
      current += config.DamageUpgradeChance;
      
      if (randomValue > current && randomValue <= current + config.SpeedUpgradeChance)
      {
        UpgradeSpeed(heroModel);
      } 
    }
    
    private void UpgradeDamage(HeroModel heroModel)
    {
      heroModel.Attack.Damage.Value += heroModel.Config.DamageUpgradeStep;
    }

    private void UpgradeAttackRange(HeroModel heroModel)
    {
      heroModel.Attack.Range.Value += heroModel.Config.AttackRangeStep;
    }
    
    private void UpgradeSpeed(HeroModel heroModel)
    {
      heroModel.Speed.Value += heroModel.Config.SpeedUpgradeStep;
    }
  }
}