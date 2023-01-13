using Codebase.Enemy;
using Codebase.Hero;
using Scellecs.Morpeh;
using UniRx;
using UnityEngine;

namespace Codebase.Attack
{
  public class AttackRange : MonoBehaviour
  {
    [field: SerializeField] private SphereCollider Collider { get; set; }
    private Entity _attacker;
    private HeroModel _model;

    public void Init(Entity attacker, HeroModel model)
    {
      _model = model;
      _attacker = attacker;
      _model.Attack.Range.SubscribeWithState(Collider, UpdateRadius).AddTo(this);
    }

    private void UpdateRadius(float radius, SphereCollider sphereCollider)
    {
      sphereCollider.radius = radius;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      var attackable = other.GetComponent<AttackableProvider>();
      if (attackable != null && !attackable.Entity.Has<InAttackRange>())
      {
        ref var range = ref attackable.Entity.AddComponent<InAttackRange>();
        range.Attacker = _attacker;
      }
    }

    private void OnTriggerExit(Collider other)
    {
      var attackable = other.GetComponent<AttackableProvider>();
      if (attackable != null && attackable.Entity.Has<InAttackRange>())
      {
        attackable.Entity.RemoveComponent<InAttackRange>();
      }
    }
  }
}
