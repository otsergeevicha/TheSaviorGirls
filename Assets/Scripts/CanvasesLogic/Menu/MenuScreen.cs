using CanvasesLogic.LeaderboardModule;
using Plugins.MonoCache;
using UnityEngine;
using UnityEngine.UI;
using Vehicle;

namespace CanvasesLogic.Menu
{
    public class MenuScreen : MonoCache, IWindow
    {
        [SerializeField] private Image _activeSoundIcon;
        [SerializeField] private Image _inActiveSoundIcon;
        [SerializeField] private Toggle _toggleSound;
        
        private LeaderboardScreen _leaderboardScreen;
        private SoundOperator _soundOperator;

        private Tank _tank;
        
        public void Inject(Tank tank, SoundOperator soundOperator)
        {
            _soundOperator = soundOperator;
            _tank = tank;
        }

        public void SelectPlay()
        {
            InActive();
            _tank.OnActive();
            Time.timeScale = 1;
        }

        public void SelectSound()
        {
            if (_toggleSound.isOn) 
                _soundOperator.UnMute();
            
            if (!_toggleSound.isOn) 
                _soundOperator.Mute();
            
            ChangeIconSound(_toggleSound.isOn);
        }

        public void SelectLeaderBoard()
        {
            _leaderboardScreen.OnActive();
            InActive();
        }

        public void OnActive()
        {        
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void InActive() =>
            gameObject.SetActive(false);


        private void ChangeIconSound(bool flag)
        {
            _activeSoundIcon.gameObject.SetActive(flag);
            _inActiveSoundIcon.gameObject.SetActive(!flag);
        }
    }
}