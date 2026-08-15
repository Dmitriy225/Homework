using Atomic.Elements;
using Game;
using System;
using UnityEngine;

namespace Game
{
    public sealed class TakeDamageAnimBehaviour :
        IGameEntityInit,
        IGameEntityEnable,
        IGameEntityDisable
    {
        private static readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));
        private Animator _animator;
        private Health _health;

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
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
            _animator.SetTrigger(TakeDamage);
        }
    }
}