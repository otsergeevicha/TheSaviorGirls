using System;
using BuildLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Reflex.Core;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using TowerParts;
using TowerParts.Obstacles;
using Vehicle;

namespace Reflex
{
    public class MainSceneInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor) => 
            descriptor.OnContainerBuilt += LoadLevel;

        private void LoadLevel(Container container)
        {
            ISave save = container.Single<ISave>();
            IInputService input = container.Single<IInputService>();
            IWallet wallet = container.Single<IWallet>();
            IGameFactory gameFactory = container.Single<IGameFactory>();

            Pool pool = gameFactory.CreatePool();
            pool.Construct(gameFactory);
            
            MainPlatform mainPlatform = gameFactory.CreateMainPlatform();
            mainPlatform.Construct(new TowerBuilder(pool, mainPlatform.transform, Constants.TowerSize), pool);

            ObstaclePattern obstaclePattern = gameFactory.CreateObstaclePattern();
            
            Tank tank = gameFactory.CreateTank();
            tank.Construct(mainPlatform.GetSpawnPointTank, pool, input);
        }
    }
}