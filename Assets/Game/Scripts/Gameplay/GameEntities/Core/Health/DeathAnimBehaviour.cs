using System;
using UnityEngine;

namespace Game
{
    public sealed class DeathAnimBehaviour :
        IGameEntityInit,
        IGameEntityEnable,
        IGameEntityDisable
    {
        private static readonly int Death = Animator.StringToHash(nameof(Death));
        private Animator _animator;

        private Health _health;

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
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
            _animator.SetTrigger(Death);
        }
    }
}