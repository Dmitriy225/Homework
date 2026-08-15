using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class DeathSfxBehaviour :
        IGameEntityInit,
        IGameEntityEnable,
        IGameEntityDisable
    {
        [SerializeField]
        private AudioClip _clip;

        private AudioSource _audioSource;
        private Health _health;

        public void Init(IGameEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _health = entity.GetHealth();
        }

        public void Enable(IGameEntity entity)
        {
            _health.OnEmptied += OnHealthEmptied;
        }

        public void Disable(IGameEntity entity)
        {
            _health.OnEmptied -= OnHealthEmptied;
        }

        private void OnHealthEmptied()
        {
            _audioSource.PlayOneShot(_clip);
        }
    }
}