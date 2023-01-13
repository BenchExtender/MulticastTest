using UnityEngine;

namespace Codebase.Services.RandomService
{
  public class RandomService : IRandomService
  {
    public int Range(int a, int b)
    {
      return Random.Range(a, b);
    }
  }
}