using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class TakeDamageSfxBehaviour :
        IGameEntityInit,
        IGameEntityEnable,
        IGameEntityDisable
    {
        [SerializeField]
        private AudioClip[] _clips;

        private AudioSource _audioSource;
        private Health _health;

        public void Init(IGameEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _health = entity.GetHealth();
        }

        public void Enable(IGameEntity entity)
        {
            _health.OnReduced += OnHealthReduced;
        }

        public void Disable(IGameEntity entity)
        {
            _health.OnReduced -= OnHealthReduced;
        }

        private void OnHealthReduced(int value)
        {
            var randomIndex = UnityEngine.Random.Range(0, _clips.Length);
            _audioSource.PlayOneShot(_clips[randomIndex]);
        }
    }
}