using Codebase.Configs;
using UniRx;

namespace Codebase.Hero
{
  public class HeroModel
  {
    public ReactiveProperty<float> Speed;
    public ReactiveProperty<int> KillCount = new ReactiveProperty<int>(0);
    public HeroConfig Config { get; private set; }
    public AttackModel Attack { get; private set; }

    public HeroModel(float speed, AttackModel attack, HeroConfig config)
    {
      Speed = new ReactiveProperty<float>(speed);
      Attack = attack;
      Config = config;
    }
  }
}
