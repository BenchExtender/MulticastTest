using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Movement
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class TransformableDisposeInitializer : IInitializer 
  {
    public World World { get; set; }

    public void OnAwake()
    {
      World.GetStash<Transformable>().AsDisposable();
    }

    public void Dispose()
    {
      
    }
  }
}