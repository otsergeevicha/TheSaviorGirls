using Infrastructure.Factory.Pools;
using TowerParts;
using UnityEngine;

namespace BuildLogic
{
    public class TowerBuilder
    {
        private readonly Transform _buildPoint;

        public TowerBuilder(Pool pool, Transform buildPoint, int towerSize)
        {
            _buildPoint = buildPoint;
            LaunchBuild(pool, buildPoint, towerSize);
        }

        private void LaunchBuild(Pool pool, Transform buildPoint, int towerSize)
        {
            Transform currentPoint = buildPoint;

            for (int i = 0; i < towerSize; i++)
            {
                Block block = pool.TryGetBlock();

                block.transform.position = GetNewPosition(currentPoint, block);
                block.OnActive();
                currentPoint = block.transform;
            }
        }

        private Vector3 GetNewPosition(Transform currentPoint, Block block) => 
            new (_buildPoint.position.x, currentPoint.position.y + currentPoint.localScale.y / 2 + block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}