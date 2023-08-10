using Plugins.MonoCache;
using Reflex;

namespace CanvasesLogic.Menu
{
    public class MenuScreen : MonoCache, IWindow
    {
        public void OnActive() => 
            gameObject.SetActive(true);

        public void InActive() => 
            gameObject.SetActive(false);
    }
}