using BuildLogic;
using CanvasesLogic;
using CanvasesLogic.Menu;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Reflex.Core;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using SoundFX;
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
            TowerBuilder towerBuilder = new TowerBuilder(pool, mainPlatform.transform, Constants.TowerSize);
            mainPlatform.Construct(towerBuilder, pool);

            ObstaclePattern obstaclePattern = gameFactory.CreateObstaclePattern();

            Tank tank = gameFactory.CreateTank();
            tank.Construct(mainPlatform, pool, input);

            SoundOperator soundOperator = gameFactory.CreateSoundOperator();
            
            WindowRoot windowRoot = gameFactory.CreateWindowRoot();
            windowRoot.Construct(save, tank, soundOperator, obstaclePattern, towerBuilder);
        }
    }
}