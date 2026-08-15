using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class ItemViewInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _clip;

        [SerializeField]
        private ParticleSystem _particle;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IGameEntity entity)
        {
            entity.GetInteractEvent().Subscribe(_ => _audioSource.PlayOneShot(_clip)).AddTo(_disposableComposite);
            entity.GetInteractEvent().Subscribe(_ => _particle.Play()).AddTo(_disposableComposite);
            entity.WhenDispose(_disposableComposite.Dispose);
        }
    }
}