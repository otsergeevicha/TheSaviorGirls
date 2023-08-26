using Plugins.MonoCache;

namespace CanvasesLogic.LeaderboardModule
{
    public class LeaderboardScreen : MonoCache, IWindow
    {
        public void OnActive() =>
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);
    }
}