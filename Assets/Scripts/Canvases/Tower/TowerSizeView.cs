﻿using Plugins.MonoCache;
using TMPro;
using TowerParts;
using UnityEngine;

namespace Canvases.Tower
{
    public class TowerSizeView : MonoCache
    {
        [SerializeField] private TMP_Text _sizeView;
        [SerializeField] private MainPlatform _tower;

        protected override void OnEnabled() =>
            _tower.SizeUpdated += OnSizeUpdated;

        protected override void OnDisabled() =>
            _tower.SizeUpdated -= OnSizeUpdated;

        private void OnSizeUpdated(int size)
        {
            if (size <= 0)
                _sizeView.enabled = false;
            else
            {
                _sizeView.enabled = true;
                _sizeView.text = size.ToString();
            }
        }
    }
}