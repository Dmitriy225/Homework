using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class GameOverPresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;
        private readonly IWorldBounds _worldBounds;

        public GameOverPresenter(
            IGameUI gameUI,
            ISnake snake,
            IDifficulty difficulty,
            IWorldBounds worldBounds)
        {
            _gameUI = gameUI;
            _snake = snake;
            _difficulty = difficulty;
            _worldBounds = worldBounds;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
            _snake.OnSelfCollided += OnSnakeSelfCollided;
            _difficulty.OnStateChanged += OnLevelChanged;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
            _snake.OnSelfCollided -= OnSnakeSelfCollided;
            _difficulty.OnStateChanged -= OnLevelChanged;
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

        private void OnLevelChanged()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                _gameUI.GameOver(true);
            }
        }
    }
}