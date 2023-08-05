using Infrastructure.Factory.Pools;
using TowerParts;
using UnityEngine;

namespace BuildLogic
{
    public class TowerBuilder
    {
        private readonly Transform _buildPoint;
        private readonly int _towerSize;
        private readonly Pool _pool;

        public TowerBuilder(Pool pool, Transform buildPoint, int towerSize)
        {
            _pool = pool;
            _towerSize = towerSize;
            _buildPoint = buildPoint;
        }

        public void LaunchBuild()
        {
            Transform currentPoint = _buildPoint;

            for (int i = 0; i < _towerSize; i++)
            {
                Block block = _pool.TryGetBlock();

                block.transform.position = GetNewPosition(currentPoint, block);
                block.OnActive();
                currentPoint = block.transform;
            }
        }

        private Vector3 GetNewPosition(Transform currentPoint, Block block) => 
            new (_buildPoint.position.x, currentPoint.position.y + currentPoint.localScale.y / 2 + block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}