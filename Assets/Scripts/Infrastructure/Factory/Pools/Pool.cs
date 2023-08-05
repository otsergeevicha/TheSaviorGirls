using System.Linq;
using Ammo;
using Infrastructure.Factory.Pools.Ammo;
using Infrastructure.Factory.Pools.Blocks;
using Plugins.MonoCache;
using Services.Factory;
using TowerParts;

namespace Infrastructure.Factory.Pools
{
    public class Pool : MonoCache
    {
        private BlockPool _blockPool;
        private BulletPool _bulletPool;

        public void Construct(IGameFactory gameFactory)
        {
            _blockPool = new BlockPool(gameFactory);
            _bulletPool = new BulletPool(gameFactory);
        }

        public Block TryGetBlock() =>
            _blockPool.Get().FirstOrDefault(block =>
                block.isActiveAndEnabled == false);

        public Bullet TryGetBullet() =>
            _bulletPool.Get().FirstOrDefault(bullet =>
                bullet.isActiveAndEnabled == false);
    }
}