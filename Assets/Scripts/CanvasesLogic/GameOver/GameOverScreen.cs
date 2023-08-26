using Plugins.MonoCache;

namespace CanvasesLogic.GameOver
{
    public class GameOverScreen : MonoCache, IWindow
    {
        public void OnActive() =>
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);
    }
}