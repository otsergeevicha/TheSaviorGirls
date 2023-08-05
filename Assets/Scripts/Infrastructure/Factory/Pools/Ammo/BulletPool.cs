using Ammo;
using Services.Factory;

namespace Infrastructure.Factory.Pools.Ammo
{
    public class BulletPool
    {
        private readonly Bullet[] _bullets = new Bullet[Constants.CountSpawnBullets];
    
        public BulletPool(IGameFactory factory)
        {
            for (int i = 0; i < _bullets.Length; i++)
            {
                _bullets[i] = factory.CreateBullet();
                _bullets[i].InActive();
            }
        }

        public Bullet[] Get() =>
            _bullets;
    }
}