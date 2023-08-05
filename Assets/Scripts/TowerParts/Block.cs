using Plugins.MonoCache;

namespace TowerParts
{
    public class Block : MonoCache
    {
        public void OnActive() => 
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);
    }
}