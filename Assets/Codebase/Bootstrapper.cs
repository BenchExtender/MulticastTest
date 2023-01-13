using System;
using UnityEngine;
using Zenject;

namespace Codebase
{
    public class Bootstrapper : MonoBehaviour
    {
        [field: SerializeField] private SceneContext Context { get; set; }

        private void Start()
        {
            Context.Run();
        }
    }
}
