using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Attack
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class AttackableProvider : MonoProvider<Attackable> 
  {
  }
}