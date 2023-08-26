using System;
using BuildLogic;
using CanvasesLogic.Menu;
using Plugins.MonoCache;
using TMPro;
using TowerParts.Obstacles;
using UnityEngine;
using UnityEngine.UI;
using Vehicle;

namespace CanvasesLogic.WinModule
{
    public class VictoryScreen : MonoCache, IWindow
    {
        [SerializeField] private TMP_Text _destroyRings;
        [SerializeField] private TMP_Text _misses;
        [SerializeField] private TMP_Text _spentBullets;

        [SerializeField] private Toggle _toggleDestroyRingsUp;
        [SerializeField] private Toggle _toggleDestroyRingsDown;
        
        [SerializeField] private Toggle _toggleMissesUp;
        [SerializeField] private Toggle _toggleMissesDown;
        
        [SerializeField] private Toggle _toggleSpentBulletsUp;
        [SerializeField] private Toggle _toggleSpentBulletsDown;
        
        private Tank _tank;
        private ObstaclePattern _obstaclePattern;
        private TowerBuilder _towerBuilder;
        private MenuScreen _menuScreen;

        public void Inject(Tank tank, ObstaclePattern obstaclePattern, TowerBuilder towerBuilder, MenuScreen menuScreen)
        {
            _menuScreen = menuScreen;
            _towerBuilder = towerBuilder;
            _obstaclePattern = obstaclePattern;
            _tank = tank;
        }

        public void SelectRestart()
        {
            _menuScreen.SelectPlay();
            InActive();
        }

        public void SelectNext()
        {
            _menuScreen.OnActive();
            InActive();
        }

        public void OnActive()
        {
            _destroyRings.text = _towerBuilder.TowerSize.ToString();
            _misses.text = _obstaclePattern.CurrentCountCollision.ToString();
            _spentBullets.text = _tank.GetCountSpentBullets().ToString();

            SelectorStars();
            
            gameObject.SetActive(true);
        }

        private void SelectorStars()
        {
            _toggleDestroyRingsUp.isOn = true;
            _toggleDestroyRingsDown.isOn = true;

            MissesStars();
            SpentBulletsStars();
        }

        public void InActive() => 
            gameObject.SetActive(false);

        private void MissesStars()
        {
            bool flag = _obstaclePattern.CurrentCountCollision < _tank.GetCountSpentBullets() / 2;
            
            _toggleMissesUp.isOn = flag;
            _toggleMissesDown.isOn = flag;
        }

        private void SpentBulletsStars()
        {
            bool flag = _towerBuilder.TowerSize * 1.5 >= _tank.GetCountSpentBullets();

            _toggleSpentBulletsUp.isOn = flag;
            _toggleSpentBulletsDown.isOn = flag;
        }
    }
}