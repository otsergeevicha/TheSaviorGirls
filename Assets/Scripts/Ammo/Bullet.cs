using Cysharp.Threading.Tasks;
using Plugins.MonoCache;
using TowerParts;
using TowerParts.Obstacles;
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
            if (hit.TryGetComponent(out Block block))
            {
                block.Break();
                InActive();
            }

            if (hit.TryGetComponent(out Obstacle _))
                Bounce();
        }

        private void Bounce()
        {
            _rigidbody.velocity = (Vector3.back + Vector3.up) * Constants.BulletSpeed;
            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(Constants.ExplosionForce, transform.position + new Vector3(0, -1, 1),
                Constants.ExplosionRadius);

            TrackerBullet().Forget();
        }

        private async UniTaskVoid TrackerBullet()
        {
            while (transform.position.y < Constants.CameraPositionY) 
                await UniTask.Yield();
            
            InActive();
        }
    }
}