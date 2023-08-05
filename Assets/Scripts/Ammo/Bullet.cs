using Plugins.MonoCache;
using UnityEngine;

namespace Ammo
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Bullet : MonoCache
    {
        public void OnActive() => 
            gameObject.SetActive(true);
        
        public void InActive() => 
            gameObject.SetActive(false);

        public void Shot(Transform shootPoint)
        {
            OnActive();
            transform.position = shootPoint.position;
        }
    }
}