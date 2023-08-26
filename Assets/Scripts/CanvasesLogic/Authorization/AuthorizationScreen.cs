using Plugins.MonoCache;

namespace CanvasesLogic.Authorization
{
    public class AuthorizationScreen : MonoCache, IWindow
    {
        public void OnActive() =>
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);
    }
}