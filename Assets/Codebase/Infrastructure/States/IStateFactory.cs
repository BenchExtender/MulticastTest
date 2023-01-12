namespace Codebase.Infrastructure.States
{
  public interface IStateFactory
  {
    IExitableState Create<T>() where T : IExitableState;
  }
}