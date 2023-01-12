using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Movement
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public class MovementSystem : ScriptableObject, ISystem 
  {
    public World World { get; set; }
    private Filter _filter;

    public void OnAwake()
    {
      _filter = World.Filter.With<MovementVelocity>().With<Transformable>();
    }

    public void OnUpdate(float deltaTime)
    {
      foreach (var entity in _filter)
      {
        ref var velocity = ref entity.GetComponent<MovementVelocity>();
        ref var view = ref entity.GetComponent<Transformable>();
        view.Transform.position += velocity.Velocity;
      }
    }

    public void Dispose() { }
  }
}