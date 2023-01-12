using System;
using Zenject;

namespace Codebase.Infrastructure.States
{
  public class BaseStateFactory : PlaceholderFactory<Type, IExitableState>
  {
  }
}
