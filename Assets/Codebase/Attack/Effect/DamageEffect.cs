using System.Collections;
using UnityEngine;

namespace Codebase.Attack.DamageEffect
{
  public class DamageEffect : MonoBehaviour
  {
    [field: SerializeField] private MeshRenderer Renderer { get; set; }
    [field: SerializeField] private Color DamagedColor { get; set; }
    [field: SerializeField] private float Duration { get; set; } = 0.25f;

    private Color _originalColor;
    private Coroutine _effectCoroutine;

    private void Awake()
    {
      _originalColor = Renderer.material.color;
    }

    public void Play()
    {
      if(_effectCoroutine != null) return;
      
      _effectCoroutine = StartCoroutine(Effect());
    }


    private IEnumerator Effect()
    {
      Renderer.material.color = DamagedColor;
      yield return new WaitForSeconds(Duration);
      Renderer.material.color = _originalColor;
      _effectCoroutine = null;
    }

    private void OnDisable()
    {
      _effectCoroutine = null;
    }
  }
}
