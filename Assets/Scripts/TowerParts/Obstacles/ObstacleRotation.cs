using DG.Tweening;
using Plugins.MonoCache;
using UnityEngine;

namespace TowerParts.Obstacles
{
    public class ObstacleRotation : MonoCache
    {
        private void Start() => 
            transform.DORotate(new Vector3(0, 360, 0), Constants.AnimationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}