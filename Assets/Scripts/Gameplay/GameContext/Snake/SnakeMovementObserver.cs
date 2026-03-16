using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeMovementObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly SnakeCoinConsumer _coinConsumer;
        private readonly CoinManager _coinManager;

        public SnakeMovementObserver(
            ISnake snake,
            SnakeCoinConsumer coinConsumer,
            CoinManager coinManager)
        {
            _snake = snake;
            _coinConsumer = coinConsumer;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if (!_coinManager.Contains(position))
            {
                return;
            }

            _coinConsumer.Consume(_coinManager.GetCoin(position));
        }
    }
}