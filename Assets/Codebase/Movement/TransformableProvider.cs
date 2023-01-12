using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Movement
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public sealed class TransformableProvider : MonoProvider<Transformable> 
  {
  }
}