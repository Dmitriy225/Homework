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
            Spawn();
            _difficulty.OnStateChanged += Spawn;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= Spawn;
        }

        private void Spawn()
        {
            _coinManager.Spawn(_difficulty.Current + 1);
        }
    }
}