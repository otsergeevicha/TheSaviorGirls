using Infrastructure.Factory.Pools;
using TowerParts;
using UnityEngine;

namespace BuildLogic
{
    public class TowerBuilder
    {
        private readonly Transform _buildPoint;
        private readonly Pool _pool;
        private Color[] _colors;
        public int TowerSize { get; private set; }

        public TowerBuilder(Pool pool, Transform buildPoint, int towerSize)
        {
            _pool = pool;
            TowerSize = towerSize;
            _buildPoint = buildPoint;
        }

        public void SetColors(Color[] colors) => 
            _colors = colors;

        public void LaunchBuild()
        {
            Transform currentPoint = _buildPoint;

            if (_colors.Length != 0)
            {
                for (int i = 0; i < TowerSize; i++)
                {
                    Block block = _pool.TryGetBlock();

                    block.transform.position = GetNewPosition(currentPoint, block);
                    block.ResetParticle();
                    block.OnActive();
                    block.SetColor(_colors[Random.Range(0, _colors.Length)]);
                    currentPoint = block.transform;
                }
            }
        }

        private Vector3 GetNewPosition(Transform currentPoint, Block block) => 
            new (_buildPoint.position.x, currentPoint.position.y + currentPoint.localScale.y / 2 + block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}