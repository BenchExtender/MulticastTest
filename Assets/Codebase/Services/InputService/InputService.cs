using UnityEngine;

namespace Codebase.Services.InputService
{
  public class InputService : IInputService
  {
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    public Vector2 MovementDirection => new Vector2(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VerticalAxisName));
  }
}