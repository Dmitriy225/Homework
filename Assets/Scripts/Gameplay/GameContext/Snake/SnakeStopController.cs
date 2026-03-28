using Modules;
using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class SnakeStopController : IInitializable, IDisposable
    {
        private IDifficulty _difficulty;
        private readonly ISnake _snake;

        public SnakeStopController(IDifficulty difficulty, ISnake snake)
        {
            this._difficulty = difficulty;
            this._snake = snake;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnLevelChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnLevelChanged;
        }

        private void OnLevelChanged()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                _snake.SetSpeed(default);
            }
        }
    }
}