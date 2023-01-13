using System.Collections;
using UnityEngine;

namespace Codebase.Services.CoroutineRunner
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
  }
}