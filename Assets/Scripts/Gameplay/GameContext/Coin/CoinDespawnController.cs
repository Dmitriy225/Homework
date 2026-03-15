using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinDespawnController : IInitializable, IDisposable
    {
        private readonly SnakeCoinConsumer _coinConsumer;
        private readonly CoinManager _coinManager;

        public CoinDespawnController(
            SnakeCoinConsumer coinConsumer,
            CoinManager coinManager)
        {
            _coinConsumer = coinConsumer;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _coinConsumer.OnConsumed += Despawn;
        }

        public void Dispose()
        {
            _coinConsumer.OnConsumed -= Despawn;
        }

        private void Despawn(ICoin coin)
        {
            _coinManager.Despawn(coin);
        }
    }
}