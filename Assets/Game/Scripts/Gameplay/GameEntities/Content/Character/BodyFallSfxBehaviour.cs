using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class BodyFallSfxBehaviour :
        IGameEntityInit,
        IGameEntityDispose
    {
        private const string animBodyFallEventKey = "body_fall_event";

        [SerializeField]
        private AudioClip _clip;

        private AudioSource _audioSource;
        private AnimationEvents _animEvents;

        public void Init(IGameEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _animEvents = entity.GetAnimEvents();
            _animEvents.Subscribe(animBodyFallEventKey, OnBodyFallEvent);
        }

        public void Dispose(IGameEntity entity)
        {
            _animEvents.Unsubscribe(animBodyFallEventKey, OnBodyFallEvent);
        }

        private void OnBodyFallEvent()
        {
            _audioSource.PlayOneShot(_clip);
        }
    }
}