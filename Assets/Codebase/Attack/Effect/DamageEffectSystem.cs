using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Attack.Effect
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class DamageEffectSystem : ISystem 
    {
        public World World { get; set; }
        private Filter _filter;

        public void OnAwake()
        {
            _filter = World.Filter.With<DamagedState>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                PlayEffect(entity);
                entity.RemoveComponent<DamagedState>();
            }
        }
        
        
        private void PlayEffect(Entity entity)
        {
            var damageEffect = entity.GetComponent<DamageEffect>(out bool hasEffect);
            if (hasEffect)
            {
                damageEffect.Player.Play();
            }
        }

        public void Dispose() { }
    }
}