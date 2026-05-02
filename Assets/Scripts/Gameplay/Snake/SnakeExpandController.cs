using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeExpandController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly ISnake _snake;

        public SnakeExpandController(CoinManager coinManager, ISnake snake)
        {
            _coinManager = coinManager;
            _snake = snake;
        }

        public void Initialize()
        {
            _coinManager.OnConsumed += OnCoinConsumed;
        }

        public void Dispose()
        {
            _coinManager.OnConsumed -= OnCoinConsumed;
        }

        private void OnCoinConsumed(ICoin coin)
        {
            _snake.Expand(coin.Bones);
        }
    }
}