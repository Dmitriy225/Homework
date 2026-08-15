using System;
using UnityEngine;

namespace Game
{
    public sealed class AimAnimBehaviour : IGameEntityInit, IGameEntityTick
    {
        private static readonly int IsAiming = Animator.StringToHash(nameof(IsAiming));
        private Animator _animator;

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _animator.SetBool(IsAiming, entity.GetPostAimTimer().IsStarted());
        }
    }
}