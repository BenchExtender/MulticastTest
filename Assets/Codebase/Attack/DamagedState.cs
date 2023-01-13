using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Attack
{
  [System.Serializable]
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct DamagedState : IComponent
  {
    public Entity Dealer;
    public int Damage;
  }
}