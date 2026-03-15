using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class ScoreController : IInitializable, IDisposable
    {
        private readonly SnakeCoinConsumer _coinConsumer;
        private readonly IScore _score;

        public ScoreController(SnakeCoinConsumer coinConsumer, IScore score)
        {
            _coinConsumer = coinConsumer;
            _score = score;
        }

        public void Initialize()
        {
            _coinConsumer.OnConsumed += OnCoinConsumed;
        }

        public void Dispose()
        {
            _coinConsumer.OnConsumed -= OnCoinConsumed;
        }

        private void OnCoinConsumed(ICoin coin)
        {
            _score.Add(coin.Score);
        }
    }
}