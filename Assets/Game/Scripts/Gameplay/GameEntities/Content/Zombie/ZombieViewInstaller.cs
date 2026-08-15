using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class ZombieViewInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Animator _animator;

        public override void Install(IGameEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddBehaviour<TakeDamageAnimBehaviour>();
            entity.AddBehaviour<DeathAnimBehaviour>();
            entity.AddBehaviour<MoveAnimBehaviour>();
            entity.AddBehaviour<FireAnimBehaviour>();
        }
    }
}