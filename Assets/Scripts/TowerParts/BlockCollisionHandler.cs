using Plugins.MonoCache;

namespace TowerParts
{
    public class BlockCollisionHandler : MonoCache
    {
        private Block _block;

        private void Awake() => 
            _block = ParentGet<Block>();

        public void Break() => 
            _block.Notify();
    }
}