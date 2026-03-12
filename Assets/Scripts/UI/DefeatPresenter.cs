using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class DefeatPresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        public DefeatPresenter(IGameUI gameUI, ISnake snake, IWorldBounds worldBounds)
        {
            _gameUI = gameUI;
            _snake = snake;
            _worldBounds = worldBounds;
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
                _gameUI.GameOver(false);
            }
        }

        private void OnSnakeSelfCollided()
        {
            _gameUI.GameOver(false);
        }
    }
}