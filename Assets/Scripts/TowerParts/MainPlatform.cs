using Plugins.MonoCache;
using UnityEngine;

namespace TowerParts
{
    public class MainPlatform : MonoCache
    {
        [SerializeField] private Transform _spawnPointTank;

        public Vector3 GetSpawnPointTank => 
            _spawnPointTank.position;
    }
}