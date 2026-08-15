using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class MoveSfxBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private const string animMoveStepEventKey = "move_step_event";

        [SerializeField]
        private AudioClip[] _clips;

        private int _currentIndex;
        private AudioSource _audioSource;
        private AnimationEvents _animEvents;

        public void Init(IGameEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _animEvents = entity.GetAnimEvents();
            _animEvents.Subscribe(animMoveStepEventKey, OnMoveStepEvent);
        }

        public void Dispose(IGameEntity entity)
        {
            _animEvents.Unsubscribe(animMoveStepEventKey, OnMoveStepEvent);
        }

        private void OnMoveStepEvent()
        {
            _audioSource.PlayOneShot(_clips[_currentIndex]);

            if (_currentIndex <= _clips.Length)
            {
                _currentIndex = 0;
            }
            else
            {
                _currentIndex++;
            }
        }
    }
}