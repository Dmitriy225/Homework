using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class DifficultyGameCycleController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly GameCycle _gameCycle;

        public DifficultyGameCycleController(IDifficulty difficulty, GameCycle gameCycle)
        {
            this._difficulty = difficulty;
            this._gameCycle = gameCycle;
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
                _gameCycle.Finish(true);
            }
        }
    }
}