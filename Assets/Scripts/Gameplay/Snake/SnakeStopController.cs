using Modules;
using System;
using Zenject;

namespace Game
{
    public sealed class SnakeStopController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;

        public SnakeStopController(IDifficulty difficulty, ISnake snake)
        {
            this._difficulty = difficulty;
            this._snake = snake;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                _snake.SetActive(false);
            }
        }
    }
}