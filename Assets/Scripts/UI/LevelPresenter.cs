using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class LevelPresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;

        public LevelPresenter(IGameUI gameUI, IDifficulty difficulty)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            OnDifficultyChanged();
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current + 1, _difficulty.Max + 1);
        }
    }
}