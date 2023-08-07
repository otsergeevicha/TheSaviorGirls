using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace Vehicle
{
    public class TankShooting : MonoCache
    {
        [SerializeField] private Transform _shootPoint;

        private readonly CancellationTokenSource _shootToken = new();

        private Pool _pool;
        private bool _isAttack;
        private float _currentPositionZ;

        public void Construct(Pool pool, IInputService input)
        {
            _pool = pool;

            input.OnActiveControls();
            input.OnShoot(OnCast);
            input.OffShoot(OffCast);

            _currentPositionZ = transform.position.z;
        }

        private void OnCast() => 
            ImitationQueue().Forget();

        private void OffCast()
        {
            _isAttack = false;
            _shootToken.Cancel();
        }

        private void ReturnStartPosition() => 
            transform.DOMoveZ(_currentPositionZ, 1f);

        private async UniTaskVoid ImitationQueue()
        {
            _isAttack = true;
            
            while (_isAttack)
            {
                _pool.TryGetBullet().OnActive(_shootPoint);
                transform.DOMoveZ(transform.position.z - .2f, .15f).SetLoops(2, LoopType.Yoyo)
                    .OnComplete(ReturnStartPosition);
                await UniTask.Delay(Constants.DelayShots);
            }
        }
    }
}