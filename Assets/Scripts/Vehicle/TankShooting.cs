using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace Vehicle
{
    public class TankShooting : MonoCache
    {
        [SerializeField] private Transform _shootPoint;
        
        private readonly CancellationTokenSource _shootToken = new ();
        
        private Pool _pool;
        private bool _isAttack;

        public void Construct(Pool pool, IInputService input)
        {
            _pool = pool;
            
            input.OnActiveControls();
            input.OnShoot(OnCast);
            input.OffShoot(OffCast);
        }

        private async UniTaskVoid ImitationQueue()
        {
            while (_isAttack)
            {
                _pool.TryGetBullet().OnActive(_shootPoint);
                await UniTask.Delay(Constants.DelayShots);
            }
        }

        private void OnCast()
        {
            _isAttack = true;
            ImitationQueue().Forget();
        }

        private void OffCast()
        {
            _isAttack = false;
            _shootToken.Cancel();
        }
    }
}