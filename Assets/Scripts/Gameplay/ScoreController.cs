using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class ScoreController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly IScore _score;

        public ScoreController(CoinManager coinManager, IScore score)
        {
            _coinManager = coinManager;
            _score = score;
        }

        public void Initialize()
        {
            _coinManager.OnConsumed += OnCoinConsumed;
        }

        public void Dispose()
        {
            _coinManager.OnConsumed -= OnCoinConsumed;
        }

        private void OnCoinConsumed(ICoin coin)
        {
            _score.Add(coin.Score);
        }
    }
}