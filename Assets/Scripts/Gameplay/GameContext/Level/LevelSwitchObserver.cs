using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class LevelSwitchObserver : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public LevelSwitchObserver(IDifficulty difficulty, ISnake snake, CoinManager coinManager)
        {
            _difficulty = difficulty;
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            SpawnCoins();
            SetSnakeSpeed();
            _difficulty.OnStateChanged += SpawnCoins;
            _difficulty.OnStateChanged += SetSnakeSpeed;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= SpawnCoins;
            _difficulty.OnStateChanged -= SetSnakeSpeed;
        }

        private void SpawnCoins()
        {
            _coinManager.Spawn(_difficulty.Current + 1);
        }

        private void SetSnakeSpeed()
        {
            _snake.SetSpeed(_difficulty.Current + 1);
        }
    }
}