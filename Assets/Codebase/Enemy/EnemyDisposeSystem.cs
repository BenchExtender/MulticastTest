using Codebase.Attack;
using Codebase.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Enemy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class EnemyDisposeSystem : ISystem 
    {
        public World World { get; set; }

        private Filter _filter;

        public void OnAwake()
        {
            _filter = World.Filter
                .With<EnemyComponent>()
                .With<DeadState>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var transform = entity.GetComponent<Transformable>().Transform;
                Object.Destroy(transform.gameObject);
                entity.Dispose();
            }
        }

        public void Dispose()
        {
            
        }
    }
}