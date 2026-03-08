using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyPool : Pool<EnemyShip>
    {
        [SerializeField]
        private BulletManager _bulletManager;

        [SerializeField]
        private PlayerShip _target;

        protected override void OnCreate(EnemyShip item)
        {
            base.OnCreate(item);
            item.Construct(_bulletManager, _target);
        }
    }
}