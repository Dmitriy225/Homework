using Modules;
using UnityEngine;

namespace SnakeGame
{
    public sealed class CoinDespawnController
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public CoinDespawnController(ISnake snake, CoinManager coinManager)
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

        private void OnSnakeMoved(Vector2Int key)
        {
            _coinManager.Despawn(key);
        }
    }
}