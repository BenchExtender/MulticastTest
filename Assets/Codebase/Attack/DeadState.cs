using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Attack
{
  [System.Serializable]
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct DeadState : IComponent
  {
    public Entity Killer;
  }
}