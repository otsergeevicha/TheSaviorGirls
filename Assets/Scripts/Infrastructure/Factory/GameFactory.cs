﻿using Ammo;
using CanvasesLogic;
using CanvasesLogic.Menu;
using Infrastructure.Factory.Pools;
using Reflex;
using Services.Assets;
using Services.Factory;
using SoundFX;
using TowerParts;
using TowerParts.Obstacles;
using Vehicle;

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

        public Tank CreateTank() =>
            _assetsProvider.InstantiateEntity(Constants.TankPath).GetComponent<Tank>();

        public Bullet CreateBullet() =>
            _assetsProvider.InstantiateEntity(Constants.BulletPath).GetComponent<Bullet>();

        public ObstaclePattern CreateObstaclePattern() =>
            _assetsProvider.InstantiateEntity(Constants.ObstacleHolderPath).GetComponent<ObstaclePattern>();

        public SoundOperator CreateSoundOperator() =>
            _assetsProvider.InstantiateEntity(Constants.SoundOperatorPath).GetComponent<SoundOperator>();
        
        public WindowRoot CreateWindowRoot() =>
            _assetsProvider.InstantiateEntity(Constants.WindowRootPath).GetComponent<WindowRoot>();
    }
}