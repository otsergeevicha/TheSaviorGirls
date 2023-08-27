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

        private IInputService _input;
        private Pool _pool;
        private bool _isAttack;
        private float _currentPositionZ;
        public int CountShots { get; private set; } = 0;

        public void Construct(Pool pool, IInputService input)
        {
            _input = input;
            _pool = pool;
            
            input.OnShoot(OnCast);
            input.OffShoot(OffCast);

            _currentPositionZ = transform.position.z;
        }

        public void OnActive() => 
            _input.OnActiveControls();
        
        public void InActive() => 
            _input.InActiveControls();

        public void ResetCountShots() =>
            CountShots = 0;

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
                CountShots++;
                
                _pool.TryGetBullet().OnActive(_shootPoint);
                transform.DOMoveZ(transform.position.z - .2f, .15f).SetLoops(2, LoopType.Yoyo)
                    .OnComplete(ReturnStartPosition);
                await UniTask.Delay(Constants.DelayShots);
            }
        }
    }
}