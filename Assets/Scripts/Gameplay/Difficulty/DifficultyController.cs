using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class DifficultyController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly IDifficulty _difficulty;

        public DifficultyController(CoinManager coinManager, IDifficulty difficulty)
        {
            _coinManager = coinManager;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _coinManager.OnEmptied += OnCoinManagerEmptied;
        }

        public void Dispose()
        {
            _coinManager.OnEmptied -= OnCoinManagerEmptied;
        }

        private void OnCoinManagerEmptied()
        {
            _difficulty.Next(out int _);
        }
    }
}