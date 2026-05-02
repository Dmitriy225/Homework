using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeGameCycleController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;
        private readonly GameCycle _cycle;

        public SnakeGameCycleController(ISnake snake, IWorldBounds worldBounds, GameCycle cycle)
        {
            _snake = snake;
            _worldBounds = worldBounds;
            _cycle = cycle;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
            _snake.OnSelfCollided += OnSnakeSelfCollided;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
            _snake.OnSelfCollided -= OnSnakeSelfCollided;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if (!_worldBounds.IsInBounds(position))
            {
                _cycle.Finish(false);
            }
        }

        private void OnSnakeSelfCollided()
        {
            _cycle.Finish(false);
        }
    }
}