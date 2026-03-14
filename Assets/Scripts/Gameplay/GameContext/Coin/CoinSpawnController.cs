using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinSpawnController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;

        public CoinSpawnController(IDifficulty difficulty, CoinManager coinManager)
        {
            _difficulty = difficulty;
            _coinManager = coinManager;
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
            _coinManager.Spawn(_difficulty.Current + 1);
        }
    }
}