using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace Vehicle
{
    [RequireComponent(typeof(TankShooting))]
    public class Tank : MonoCache
    {
        public void Construct(Vector3 spawnPoint, Pool pool, IInputService input)
        {
            transform.position = spawnPoint;
            Get<TankShooting>().Construct(pool, input);
        }
    }
}