using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class BulletPoolInstaller : IEntityInstaller<IGameContext>
    {
        [SerializeField]
        private GameEntityPool _pool;

        [SerializeField]
        private GameEntity _prefab;

        [SerializeField]
        private int _count;

        public void Install(IGameContext context)
        {
            _pool.Init(_prefab, _count);
            context.AddBulletPool(_pool);
        }
    }
}