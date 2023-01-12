using UniRx;

namespace Codebase.Hero
{
  public class AttackModel
  {
    public ReactiveProperty<int> Damage;
    public ReactiveProperty<float> Range;
    public float AttackDelay { get; private set; }
    public float LastAttackTime;

    public AttackModel(int damagePerSecond, float attackRange, float attackDelay)
    {
      AttackDelay = attackDelay;
      Damage = new ReactiveProperty<int>(damagePerSecond);
      Range = new ReactiveProperty<float>(attackRange);
    }
  }
}