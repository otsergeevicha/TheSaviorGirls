using CanvasesLogic.Authorization;
using CanvasesLogic.GameOver;
using CanvasesLogic.LeaderboardModule;
using CanvasesLogic.Menu;
using CanvasesLogic.WinModule;
using Plugins.MonoCache;
using Services.SaveLoad;
using UnityEngine;
using Vehicle;

namespace CanvasesLogic
{
    [RequireComponent(typeof(Canvas))]
    public class WindowRoot : MonoCache
    {
        private VictoryScreen _victoryScreen;
        private GameOverScreen _gameOverScreen;
        private MenuScreen _menuScreen;
        private AuthorizationScreen _authorizationScreen;
        private LeaderboardScreen _leaderboardScreen;

        public void Construct(ISave save, Tank tank)
        {
            _victoryScreen = ChildrenGet<VictoryScreen>();
            _menuScreen = ChildrenGet<MenuScreen>();
            _leaderboardScreen = ChildrenGet<LeaderboardScreen>();
            _authorizationScreen = ChildrenGet<AuthorizationScreen>();
            _gameOverScreen = ChildrenGet<GameOverScreen>();

            tank.OnVictoried += OnPlayerWin;
            tank.OnGameOvered += OnPlayerGameOver;
            tank.InActive();

            _menuScreen.Inject(tank);
            
            DefaultConfigWindows();
        }

        public void DefaultConfigWindows()
        {
            _menuScreen.OnActive();

            _victoryScreen.InActive();
            _gameOverScreen.InActive();
            _authorizationScreen.InActive();
            _leaderboardScreen.InActive();
        }

        private void OnPlayerWin() =>
            _victoryScreen.OnActive();

        private void OnPlayerGameOver() =>
            _gameOverScreen.OnActive();
    }
}