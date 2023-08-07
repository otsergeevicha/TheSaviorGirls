﻿using System;
using System.Linq;
using BuildLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using UnityEngine;

namespace TowerParts
{
    public class MainPlatform : MonoCache
    {
        [SerializeField] private Transform _spawnPointTank;

        public event Action<int> SizeUpdated; 

        private TowerBuilder _towerBuilder;
        private Block[] _blocks;

        public Vector3 GetSpawnPointTank => 
            _spawnPointTank.position;

        public void Construct(TowerBuilder towerBuilder, Pool pool)
        {
            _towerBuilder = towerBuilder;
            _towerBuilder.LaunchBuild();

            _blocks = pool.GetAllBlocks();

            for (int i = 0; i < _blocks.Length; i++) 
                _blocks[i].Broken += OnBroken;
            
            SizeUpdated?.Invoke(GetActualSize());
        }

        private void OnBroken(Block block)
        {
            block.Broken -= OnBroken;
            
            block.InActive();
            TowerDisplacement(block);
        }

        private void TowerDisplacement(Block block)
        {
            for (int i = 0; i < _blocks.Length; i++)
                _blocks[i].transform.position = new Vector3(_blocks[i].transform.position.x,
                    _blocks[i].transform.position.y - block.transform.localScale.y, _blocks[i].transform.position.z);
            
            SizeUpdated?.Invoke(GetActualSize());
        }

        private int GetActualSize() => 
            _blocks.Count(block => block.isActiveAndEnabled);
    }
}