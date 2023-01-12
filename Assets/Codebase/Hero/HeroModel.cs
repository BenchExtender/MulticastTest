using Codebase.Configs;
using UniRx;

namespace Codebase.Hero
{
  public class HeroModel
  {
    public ReactiveProperty<float> Speed;

    public ReactiveProperty<float> DamagePerSecond;

    public ReactiveProperty<float> Radius;
    public HeroConfig Config { get; private set; }

    public HeroModel(float speed, float damagePerSecond, float attackRadius, HeroConfig config)
    {
      Speed = new ReactiveProperty<float>(speed);
      DamagePerSecond = new ReactiveProperty<float>(damagePerSecond);
      Radius = new ReactiveProperty<float>(attackRadius);
      Config = config;
    }
  }
}
