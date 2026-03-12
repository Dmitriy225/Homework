using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class LevelManager : IInitializable
    {
        private readonly IMemoryPool<Vector2Int, Coin> _coinPool;
        private readonly IWorldBounds _worldBounds;

        public LevelManager(
            IMemoryPool<Vector2Int, Coin> coinPool,
            IWorldBounds worldBounds
        )
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
        }

        public void Initialize()
        {
            for (int i = 0; i < 5; i++)
            {
                _coinPool.Spawn(_worldBounds.GetRandomPosition());
            }
        }
    }
}