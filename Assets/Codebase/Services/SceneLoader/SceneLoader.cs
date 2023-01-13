using System;
using System.Collections;
using Codebase.Services.CoroutineRunner;
using UnityEngine.SceneManagement;

namespace Codebase.Services.SceneLoader
{
  public class SceneLoader : ISceneLoader
  {
    private ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Load(string sceneName, Action onLoaded)
    {
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
    }

    private IEnumerator LoadScene(string sceneName, Action onLoaded)
    {
      var operation = SceneManager.LoadSceneAsync(sceneName);
      while (!operation.isDone)
      {
        yield return null;
      }
      onLoaded?.Invoke();
    }
  }
}