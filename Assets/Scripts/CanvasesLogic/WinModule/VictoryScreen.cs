using Plugins.MonoCache;
using UnityEngine;

namespace CanvasesLogic.WinModule
{
    public class VictoryScreen : MonoCache, IWindow
    {
        [SerializeField] private Canvas _canvas;

        public void OnActive() =>
            gameObject.SetActive(true);

        public void InActive() => 
            gameObject.SetActive(false);
        
        // public void OnActive() =>
        //     _canvas.enabled = true;
        //
        // public void InActive() => 
        //     _canvas.enabled = false;
    }
}