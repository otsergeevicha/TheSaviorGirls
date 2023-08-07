using Ammo;
using Infrastructure.Factory.Pools;
using Reflex;
using TowerParts;
using TowerParts.Obstacles;
using Vehicle;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Block CreateBlock();
        Pool CreatePool();
        MainPlatform CreateMainPlatform();
        Tank CreateTank();
        Bullet CreateBullet();
        ObstaclePattern CreateObstaclePattern();
    }
}