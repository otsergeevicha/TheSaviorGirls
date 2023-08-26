using System;
using Plugins.MonoCache;

namespace TowerParts.Obstacles
{
    public class Obstacle : MonoCache
    {
        public event Action OnCollision;
        
        public void Notify() => 
            OnCollision?.Invoke();
    }
}