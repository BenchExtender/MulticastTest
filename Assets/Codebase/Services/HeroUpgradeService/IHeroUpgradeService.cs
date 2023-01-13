using Codebase.Hero;

namespace Codebase.Services.HeroUpgradeService
{
  public interface IHeroUpgradeService
  {
    public void UpgradeRandom(HeroModel heroModel);
  }
}