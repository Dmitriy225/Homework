using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class PistolViewInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private ParticleSystem _fireEffect;

        [SerializeField]
        private AudioClip _fireClip;

        [SerializeField]
        private float _minFirePitch = 0.9f;

        [SerializeField]
        private float _maxFirePitch = 1.1f;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IGameEntity entity)
        {
            
            entity.GetFireEvent().Subscribe(() => _fireEffect.Play()).AddTo(_disposableComposite);
            entity.GetFireEvent().Subscribe(() => _audioSource.pitch = Random.Range(_minFirePitch, _maxFirePitch)).AddTo(_disposableComposite);
            entity.GetFireEvent().Subscribe(() => _audioSource.PlayOneShot(_fireClip)).AddTo(_disposableComposite);
            entity.WhenDispose(_disposableComposite.Dispose);
        }
    }
}