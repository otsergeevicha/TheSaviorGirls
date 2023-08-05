using Plugins.MonoCache;
using TowerParts;
using UnityEngine;

namespace Ammo
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class Bullet : MonoCache
    {
        private Rigidbody _rigidbody;

        private void Awake() => 
            _rigidbody = Get<Rigidbody>();

        public void OnActive(Transform shootPoint)
        {
            transform.position = shootPoint.position;
            transform.LookAt(Vector3.forward);
            gameObject.SetActive(true);
            _rigidbody.velocity = transform.forward * Constants.BulletSpeed;
        }

        public void InActive() => 
            gameObject.SetActive(false);

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out BlockCollisionHandler block)) 
                block.Break();

            InActive();
        }
    }
}