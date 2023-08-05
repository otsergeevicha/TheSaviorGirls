using Infrastructure.Factory.Pools;
using Reflex;
using TowerParts;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Block CreateBlock();
        Pool CreatePool();
        MainPlatform CreateMainPlatform();
    }
}