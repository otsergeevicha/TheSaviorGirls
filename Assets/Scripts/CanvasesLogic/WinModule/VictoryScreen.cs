using Plugins.MonoCache;

namespace CanvasesLogic.WinModule
{
    public class VictoryScreen : MonoCache, IWindow
    {
        public void OnActive() =>
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);
    }
}