using Ammo;
using CanvasesLogic;
using CanvasesLogic.Menu;
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
        WindowRoot CreateWindowRoot();
        SoundOperator CreateSoundOperator();
    }
}