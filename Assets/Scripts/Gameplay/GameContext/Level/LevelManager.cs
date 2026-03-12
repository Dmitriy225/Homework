using Modules;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class LevelManager : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IMemoryPool<Vector2Int, Coin> _coinPool;
        private readonly IDifficulty _difficulty;
        private readonly IWorldBounds _worldBounds;
        private readonly Dictionary<Vector2Int, ICoin> _coinMap = new();

        public LevelManager(
            ISnake snake,
            IMemoryPool<Vector2Int, Coin> coinPool,
            IDifficulty difficulty,
            IWorldBounds worldBounds
        )
        {
            _snake = snake;
            _coinPool = coinPool;
            _difficulty = difficulty;
            _worldBounds = worldBounds;
        }

        public void Initialize()
        {
            SpawnCoins(_difficulty.Current + 1);

            _snake.OnMoved += OnSnakeMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if (!_coinMap.TryGetValue(position, out var coin))
            {
                return;
            }

            _coinMap.Remove(position);
            _coinPool.Despawn(coin);

            if (_coinMap.Keys.Count == 0)
            {
                _difficulty.Next(out int difficulty);
                SpawnCoins(difficulty + 1);
            }
        }

        private void SpawnCoins(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var position = _worldBounds.GetRandomPosition();
                _coinMap.Add(position, _coinPool.Spawn(position));
            }
        }
    }
}