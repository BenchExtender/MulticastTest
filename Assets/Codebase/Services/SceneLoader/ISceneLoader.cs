using System;

namespace Codebase.Services.SceneLoader
{
  public interface ISceneLoader
  {
    void Load(string sceneName, Action onLoaded);
  }
}
