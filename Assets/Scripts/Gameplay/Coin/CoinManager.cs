using Modules;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinManager
    {
        public event Action<ICoin> OnConsumed;
        public event Action OnEmptied;

        private readonly IMemoryPool<Vector2Int, Coin> _coinPool;
        private readonly IWorldBounds _worldBounds;
        private readonly Dictionary<Vector2Int, ICoin> _coinMap = new();
        private readonly HashSet<ICoin> _coins = new();

        public CoinManager(
            IMemoryPool<Vector2Int, Coin> coinPool,
            IWorldBounds worldBounds
        )
        {
            _coinPool = coinPool;
            _worldBounds = worldBounds;
        }

        public bool TryConsumeCoin(Vector2Int key)
        {
            if (!_coinMap.ContainsKey(key))
            {
                return false;
            }

            var coin = _coinMap[key];
            OnConsumed?.Invoke(coin);
            Despawn(coin);
            return true;
        }

        private bool Despawn(ICoin coin)
        {
            if (!_coins.Contains(coin))
            {
                return false;
            }

            _coinMap.Remove(coin.Position);
            _coins.Remove(coin);
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
                var coin = _coinPool.Spawn(key);
                _coinMap.Add(key, coin);
                _coins.Add(coin);
            }
        }
    }
}