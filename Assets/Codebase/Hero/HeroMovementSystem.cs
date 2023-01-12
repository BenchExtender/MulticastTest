using Codebase.Configs;
using Codebase.Movement;
using Codebase.Services.InputService;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Codebase.Hero
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class HeroMovementSystem : ISystem 
    {
        public World World { get; set; }
        
        private readonly IInputService _inputService;
        private readonly HeroConfig _heroConfig;
        private Filter _filter;

        public HeroMovementSystem(IInputService inputService, HeroConfig heroConfig)
        {
            _inputService = inputService;
            _heroConfig = heroConfig;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<HeroComponent>().With<MovementVelocity>();
        }

        public void OnUpdate(float deltaTime)
        {
            var inputDirection = _inputService.MovementDirection;
            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            foreach (var entity in _filter)
            {
                ref var velocity = ref entity.GetComponent<MovementVelocity>();
                velocity.Velocity = direction.normalized * _heroConfig.Speed * _heroConfig.SpeedMultiplier * deltaTime;
            }
        }

        public void Dispose() { }
    }
}