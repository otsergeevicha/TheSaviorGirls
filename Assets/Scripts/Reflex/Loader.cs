using Plugins.MonoCache;
using Reflex.Core;
using UnityEngine.SceneManagement;

namespace Reflex
{
    public class Loader : MonoCache
    {
        private void Start() => 
            ReflexSceneManager.LoadScene("Greet", LoadSceneMode.Single, builder => builder.AddInstance("beautiful"));
    }
}