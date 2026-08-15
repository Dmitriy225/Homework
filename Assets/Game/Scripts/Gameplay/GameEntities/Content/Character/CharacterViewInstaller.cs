using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class CharacterViewInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private DeathSfxBehaviour _deathSfxBehaviour;

        [SerializeField]
        private BodyFallSfxBehaviour _bodyFallSfxBehaviour;

        [SerializeField]
        private TakeDamageSfxBehaviour _takeDamageSfxBehaviour;

        [SerializeField]
        private MoveSfxBehaviour _moveSfxBehaviour;

        public override void Install(IGameEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddAudioSource(_audioSource);
            entity.AddBehaviour<TakeDamageAnimBehaviour>();
            entity.AddBehaviour(_takeDamageSfxBehaviour);
            entity.AddBehaviour<DeathAnimBehaviour>();
            entity.AddBehaviour(_deathSfxBehaviour);
            entity.AddBehaviour(_bodyFallSfxBehaviour);
            entity.AddBehaviour<MoveAnimBehaviour>();
            entity.AddBehaviour(_moveSfxBehaviour);
            entity.AddBehaviour<FireAnimBehaviour>();
            entity.AddBehaviour<AimAnimBehaviour>();
        }
    }
}