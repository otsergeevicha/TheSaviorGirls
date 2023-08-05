using Infrastructure.Factory.Pools;
using Reflex;
using Services.Assets;
using Services.Factory;
using TowerParts;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetsProvider;

        public GameFactory(IAssetsProvider assetsProvider) => 
            _assetsProvider = assetsProvider;

        public Block CreateBlock() => 
            _assetsProvider.InstantiateEntity(Constants.BlockPath).GetComponent<Block>();

        public Pool CreatePool() => 
            _assetsProvider.InstantiateEntity(Constants.PoolPath).GetComponent<Pool>();

        public MainPlatform CreateMainPlatform() => 
            _assetsProvider.InstantiateEntity(Constants.MainPlatformPath).GetComponent<MainPlatform>();
    }
}