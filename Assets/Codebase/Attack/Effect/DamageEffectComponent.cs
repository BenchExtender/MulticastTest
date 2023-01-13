using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Attack.DamageEffect
{
  [System.Serializable]
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct DamageEffectComponent : IComponent
  {
    public global::Codebase.Attack.DamageEffect.DamageEffect Effect;
  }
}