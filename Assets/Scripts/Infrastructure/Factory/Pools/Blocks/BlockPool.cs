using Services.Factory;
using TowerParts;

namespace Infrastructure.Factory.Pools.Blocks
{
    public class BlockPool
    {
        private readonly Block[] _blocks = new Block[Constants.CountSpawnBlocks];
        
        public BlockPool(IGameFactory gameFactory)
        {
            for (int i = 0; i < _blocks.Length; i++)
            {
                _blocks[i] = gameFactory.CreateBlock();
                _blocks[i].InActive();
            }
        }

        public Block[] Get() =>
            _blocks;
    }
}