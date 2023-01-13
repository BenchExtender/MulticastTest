using Codebase.Configs;
using UniRx;

namespace Codebase.Hero
{
  public class HeroModel
  {
    public ReactiveProperty<float> Speed;
    public ReactiveProperty<int> KillCount;
    public HeroConfig Config { get; private set; }
    public AttackModel Attack { get; private set; }

    public HeroModel(float speed, AttackModel attack, HeroConfig config)
    {
      Speed = new ReactiveProperty<float>(speed);
      KillCount = new ReactiveProperty<int>(0);
      Attack = attack;
      Config = config;
    }
  }
}
