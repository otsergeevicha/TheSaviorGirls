using Plugins.MonoCache;
using UnityEngine;

namespace CanvasesLogic.Menu
{
    public class SoundOperator : MonoCache
    {
        [SerializeField] private AudioSource _playSound;
        [SerializeField] private AudioSource _gameOverSound;

        private WindowRoot _windowRoot;

        public bool IsSoundStatus { get; private set; } = true;

        // protected override void OnEnabled() => 
        //      WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        //
        // protected override void OnDisabled() => 
        //      WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

        public void Inject(WindowRoot windowRoot) => 
            _windowRoot = windowRoot;

        public void Mute()
        {
            _playSound.volume = 0;
            _gameOverSound.volume = 0;
            
            IsSoundStatus = false;
        }

        public void UnMute()
        {
            _playSound.volume = 1;
            _gameOverSound.volume = 1;
            
            IsSoundStatus = true;
        }

        public void LockGame()
        {
            Time.timeScale = 0;
            _playSound.volume = 0;
            _gameOverSound.volume = 0;
        }

        public void UnLockGame()
        {
            Time.timeScale = 1;
            _playSound.volume = 1;
            _gameOverSound.volume = 1;
        }

        public void PlayMainSound()
        {
            _gameOverSound.Stop();
            _gameOverSound.volume = 0;
            
            _playSound.Play();
            _playSound.volume = 1;
        }

        public void PlayGameOverSound()
        {
            _playSound.Stop();
            _playSound.volume = 0;
            
            _gameOverSound.Play();
            _gameOverSound.volume = 1;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if (inBackground)
                OnOpenCallback();

            if (!inBackground)
            {
                OnOpenCallback();
                //InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
            }
        }

        private void OnOpenCallback()
        {
            _playSound.volume = 0;
            _gameOverSound.volume = 0;
            Time.timeScale = 0;
        }

        private void OnCloseCallback(bool _) => 
            AfterSeeAds();

        private void OnErrorCallback(string _) => 
            AfterSeeAds();

        private void AfterSeeAds()
        {
            _windowRoot.DefaultConfigWindows();
            _playSound.volume = 1;
            _gameOverSound.volume = 1;
        }
    }
}