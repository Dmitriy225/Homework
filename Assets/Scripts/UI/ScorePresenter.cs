using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public sealed class ScorePresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IScore _score;

        public ScorePresenter(IGameUI gameUI, IScore score)
        {
            _gameUI = gameUI;
            _score = score;
        }

        public void Initialize()
        {
            OnScoreChanged(_score.Current);
            _score.OnStateChanged += OnScoreChanged;
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}