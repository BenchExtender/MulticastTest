using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using Unity.IL2CPP.CompilerServices;

namespace Codebase.Enemy
{
  [System.Serializable]
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct Health : IComponent
  {
    [ReadOnly] public int Max;
    [ReadOnly] public int Current;
    public void Reset()
    {
      Current = Max;
    }
  }
}