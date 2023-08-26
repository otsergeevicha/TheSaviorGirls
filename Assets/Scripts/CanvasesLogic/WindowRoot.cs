using BuildLogic;
using CanvasesLogic.Authorization;
using CanvasesLogic.LeaderboardModule;
using CanvasesLogic.Menu;
using CanvasesLogic.WinModule;
using Plugins.MonoCache;
using Services.SaveLoad;
using SoundFX;
using TowerParts.Obstacles;
using UnityEngine;
using Vehicle;

namespace CanvasesLogic
{
    [RequireComponent(typeof(Canvas))]
    public class WindowRoot : MonoCache
    {
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private AuthorizationScreen _authorizationScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;

        public void Construct(ISave save, Tank tank, SoundOperator soundOperator, ObstaclePattern obstaclePattern,
            TowerBuilder towerBuilder)
        {
            tank.Victoriad += PlayerWin;
            tank.InActive();

            _menuScreen.Inject(tank, soundOperator, _leaderboardScreen, obstaclePattern, towerBuilder);
            _authorizationScreen.Inject(_menuScreen, _leaderboardScreen);
            _leaderboardScreen.Inject(save, _authorizationScreen, _menuScreen);
            _victoryScreen.Inject(tank, obstaclePattern, towerBuilder, _menuScreen);
            
            DefaultConfigWindows();
        }

        public void DefaultConfigWindows()
        {
            _menuScreen.OnActive();

            _victoryScreen.InActive();
            _authorizationScreen.InActive();
            _leaderboardScreen.InActive();
        }

        private void PlayerWin() =>
            _victoryScreen.OnActive();
    }
}