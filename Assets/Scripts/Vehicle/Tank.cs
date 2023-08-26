using System;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using TowerParts;
using UnityEngine;

namespace Vehicle
{
    [RequireComponent(typeof(TankShooting))]
    public class Tank : MonoCache
    {
        private TankShooting _tankShooting;
        public event Action Victoriad;
        
        public void Construct(MainPlatform mainPlatform, Pool pool, IInputService input)
        {
            transform.position = mainPlatform.GetSpawnPointTank;

            mainPlatform.Ended += TowerDestroyed;
            
            _tankShooting = Get<TankShooting>();
            _tankShooting.Construct(pool, input);
        }

        public void OnActive() =>
            _tankShooting.OnActive();

        public void InActive() =>
            _tankShooting.InActive();

        public void ResetCountShots() => 
            _tankShooting.ResetCountShots();

        public int GetCountSpentBullets() => 
            _tankShooting.CountShots;

        private void TowerDestroyed()
        {
            InActive();
            Victoriad?.Invoke();
        }
    }
}