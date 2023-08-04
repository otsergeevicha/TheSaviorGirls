﻿using Plugins.MonoCache;
using Reflex.Core;
using UnityEngine.SceneManagement;

namespace Reflex
{
    public class Loader : MonoCache
    {
        private void Start() => 
            ReflexSceneManager.LoadScene(Constants.MainScene, LoadSceneMode.Single, builder =>
                builder.AddInstance(""));
    }
}