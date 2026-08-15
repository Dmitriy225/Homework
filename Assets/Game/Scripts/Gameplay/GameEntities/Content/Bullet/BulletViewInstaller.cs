using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class BulletViewInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private TrailRenderer _trail;

        public override void Install(IGameEntity entity)
        {
            entity.WhenEnable(() => _trail.Clear());
        }
    }
}