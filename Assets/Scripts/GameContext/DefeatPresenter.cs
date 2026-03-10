using Modules;
using SnakeGame;
using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class DefeatPresenter : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;
        private readonly IGameUI _gameUI;

        public DefeatPresenter(ISnake snake, IWorldBounds worldBounds, IGameUI gameUI)
        {
            _snake = snake;
            _worldBounds = worldBounds;
            _gameUI = gameUI;
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