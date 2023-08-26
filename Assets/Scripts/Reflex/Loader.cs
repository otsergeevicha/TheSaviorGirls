using System.Collections;
using Plugins.MonoCache;
using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using PlayerPrefs = UnityEngine.PlayerPrefs;

namespace Reflex
{
    public class Loader : MonoCache
    {
        private IEnumerator Start()
        {
#if !UNITY_WEBGL || !UNITY_EDITOR
            while (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();
            
            if (PlayerAccount.IsAuthorized)
                PlayerAccount.GetCloudSaveData(OnSuccessCallback, OnErrorCallback);
            else
                LaunchGame();
#endif
            yield return new WaitForSeconds(0f);
            LaunchGame();
        }

        private void OnSuccessCallback(string data)
        {
            PlayerPrefs.SetString(Constants.Progress, data);
            PlayerPrefs.Save();
            
            LaunchGame();
        }

        private void OnErrorCallback(string _) => 
            LaunchGame();
        
        private void LaunchGame() =>
            ReflexSceneManager.LoadScene(Constants.MainScene, LoadSceneMode.Single, builder =>
                builder.AddInstance(""));
    }
}