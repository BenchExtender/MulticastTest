using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Hero.Factory
{
  public interface IHeroFactory
  {
    Entity Create();
  }
}