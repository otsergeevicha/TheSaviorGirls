using System.Linq;
using Infrastructure.Factory.Pools.Blocks;
using Plugins.MonoCache;
using Services.Factory;
using TowerParts;

namespace Infrastructure.Factory.Pools
{
    public class Pool : MonoCache
    {
        private BlockPool _blockPool;

        public void Construct(IGameFactory gameFactory) => 
            _blockPool = new BlockPool(gameFactory);

        public Block TryGetBlock() =>
            _blockPool.Get().FirstOrDefault(block =>
                block.isActiveAndEnabled == false);
    }
}