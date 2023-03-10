using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Codebase.Movement
{
  [System.Serializable]
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct Transformable : IComponent, IDisposable
  {
    public Transform Transform;

    public void Dispose()
    {
      Object.Destroy(Transform.gameObject);
    }
  }
}