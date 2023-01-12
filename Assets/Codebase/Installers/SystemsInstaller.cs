using Codebase.Attack;
using Codebase.Enemy;
using Codebase.Hero;
using Codebase.Movement;
using Zenject;

namespace Codebase.Installers
{
  public class SystemsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<MovementSystem>().AsSingle();
      Container.Bind<HeroMovementSystem>().AsSingle();
      Container.Bind<EnemySpawnSystem>().AsSingle();
      Container.Bind<EnemyDisposeSystem>().AsSingle();
      Container.Bind<AttackTargetSystem>().AsSingle();
      Container.Bind<DamageSystem>().AsSingle();
    }
  }
}
