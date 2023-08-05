using System;
using Plugins.MonoCache;

namespace TowerParts
{
    public class Block : MonoCache
    {
        public event Action<Block> Broken; 

        public void OnActive() => 
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);

        public void Notify() => 
            Broken?.Invoke(this);
    }
}