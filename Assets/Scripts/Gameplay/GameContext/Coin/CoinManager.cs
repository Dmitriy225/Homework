using Modules;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinManager
    {
        public event Action OnEmptied;

        private readonly IMemoryPool<Vector2Int, Coin> _coinPool;
        private readonly IWorldBounds _worldBounds;
        private readonly Dictionary<Vector2Int, ICoin> _coinMap = new();

        public CoinManager(
            IMemoryPool<Vector2Int, Coin> coinPool,
            IWorldBounds worldBounds
        )
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
        }

        public bool Despawn(Vector2Int key)
        {
            if (!_coinMap.TryGetValue(key, out var coin))
            {
                return false;
            }

            _coinMap.Remove(key);
            _coinPool.Despawn(coin);

            if (_coinMap.Keys.Count == 0)
            {
                OnEmptied?.Invoke();
            }

            return true;
        }

        public void Spawn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var key = _worldBounds.GetRandomPosition();
                _coinMap.Add(key, _coinPool.Spawn(key));
            }
        }

        public bool Contains(Vector2Int key)
        {
            return _coinMap.ContainsKey(key);
        }

        public ICoin GetCoin(Vector2Int key)
        {
            return _coinMap.GetValueOrDefault(key);
        }
    }
}