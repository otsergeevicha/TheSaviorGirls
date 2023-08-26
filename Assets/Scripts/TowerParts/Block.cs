using System;
using Plugins.MonoCache;
using UnityEngine;

namespace TowerParts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Block : MonoCache
    {
        [SerializeField] private ParticleSystem _destroyEffect;

        private MeshRenderer _meshRenderer;
        private ParticleSystem _effect;
        private ParticleSystemRenderer _renderer;

        public event Action<Block> Broken;

        public void ResetParticle()
        {
            _meshRenderer = Get<MeshRenderer>();
            _effect = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation);
            _renderer = _effect.GetComponent<ParticleSystemRenderer>();
        }

        public void SetColor(Color newColor)
        {
            _meshRenderer.material.color = newColor;
            _renderer.material.color = newColor;
        }

        public void OnActive() =>
            gameObject.SetActive(true);

        public void InActive() => 
            gameObject.SetActive(false);

        public void Break()
        {
            _effect.Play();
            Broken?.Invoke(this);
        }
    }
}