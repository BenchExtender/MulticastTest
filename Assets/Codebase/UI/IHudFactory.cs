using Codebase.Hero;

namespace Codebase.UI
{
  public interface IHudFactory
  {
    HudScreen Create(HeroModel heroModel);
  }
}