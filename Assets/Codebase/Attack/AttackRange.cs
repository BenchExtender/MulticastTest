using System;
using System.Collections.Generic;
using Codebase.Attack;
using Codebase.Enemy;
using Scellecs.Morpeh;
using UnityEngine;

namespace Codebase.Hero
{
  public class AttackRange : MonoBehaviour
  {
    [HideInInspector] public Entity Attacker;
    private void OnTriggerEnter(Collider other)
    {
      var attackable = other.GetComponent<AttackableProvider>();
      if (attackable != null && !attackable.Entity.Has<InAttackRange>())
      {
        ref var range = ref attackable.Entity.AddComponent<InAttackRange>();
        range.Attacker = Attacker;
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
