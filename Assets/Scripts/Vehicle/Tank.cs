using System;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace Vehicle
{
    [RequireComponent(typeof(TankShooting))]
    public class Tank : MonoCache
    {
        private TankShooting _tankShooting;
        public event Action OnVictoried;
        public event Action OnGameOvered;
        
        public void Construct(Vector3 spawnPoint, Pool pool, IInputService input)
        {
            transform.position = spawnPoint;
            _tankShooting = Get<TankShooting>();
            _tankShooting.Construct(pool, input);
        }

        public void OnActive() =>
            _tankShooting.OnActive();
        
        public void InActive() =>
            _tankShooting.InActive();
    }
}
