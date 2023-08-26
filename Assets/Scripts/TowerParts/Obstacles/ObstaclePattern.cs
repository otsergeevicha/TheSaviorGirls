using Plugins.MonoCache;
using UnityEngine;

namespace TowerParts.Obstacles
{
    [RequireComponent(typeof(ObstacleRotation))]
    public class ObstaclePattern : MonoCache
    {
        [SerializeField] private Obstacle[] _obstacles;
        
        public int CurrentCountCollision { get; private set; } = 0;

        protected override void OnEnabled()
        {
            for (int i = 0; i < _obstacles.Length; i++) 
                _obstacles[i].OnCollision += OnOnCollision;
        }

        protected override void OnDisabled()
        {
            for (int i = 0; i < _obstacles.Length; i++) 
                _obstacles[i].OnCollision -= OnOnCollision;
        }

        public void ResetCountCollision() =>
            CurrentCountCollision = 0;
        
        private void OnOnCollision() => 
            CurrentCountCollision++;
    }
}