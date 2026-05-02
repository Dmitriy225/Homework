using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinConsumeController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public CoinConsumeController(
            ISnake snake,
            CoinManager coinManager)
        {
            _snake = snake;
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
            _coinManager.TryConsumeCoin(position);
        }
    }
}