using UnityEngine;

namespace Codebase.Services.InputService
{
  public interface IInputService
  {
    Vector2 MovementDirection { get; }
  }
}
