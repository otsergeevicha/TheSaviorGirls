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
        private ISave _save;
        private IInputService _input;
        private IWallet _wallet;
        private IGameFactory _gameFactory;
        
        private Pool _pool;
        private MainPlatform _mainPlatform;
        private TowerBuilder _towerBuilder;
        private Tank _tank;
        private ObstaclePattern _obstaclePattern;

        public void InstallBindings(ContainerDescriptor descriptor) => 
            descriptor.OnContainerBuilt += LoadLevel;

        private void LoadLevel(Container container)
        {
             _save = container.Single<ISave>();
            _input = container.Single<IInputService>();
            _wallet = container.Single<IWallet>();
            _gameFactory = container.Single<IGameFactory>();
        
            _pool = _gameFactory.CreatePool();
            _pool.Construct(_gameFactory);
            
            _mainPlatform = _gameFactory.CreateMainPlatform();
            _towerBuilder = new TowerBuilder(_pool, _mainPlatform.transform, Constants.TowerSize);
            _mainPlatform.Construct(_towerBuilder, _pool);
        
            _obstaclePattern = _gameFactory.CreateObstaclePattern();
            
            _tank = _gameFactory.CreateTank();
            _tank.Construct(_mainPlatform.GetSpawnPointTank, _pool, _input);
        }
    }
}