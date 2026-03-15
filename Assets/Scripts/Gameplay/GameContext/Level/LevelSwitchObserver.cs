using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class LevelSwitchObserver : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;

        public LevelSwitchObserver(IDifficulty difficulty, CoinManager coinManager)
        {
            _difficulty = difficulty;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            SpawnCoins();
            _difficulty.OnStateChanged += SpawnCoins;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= SpawnCoins;
        }

        private void SpawnCoins()
        {
            _coinManager.Spawn(_difficulty.Current + 1);
        }
    }
}