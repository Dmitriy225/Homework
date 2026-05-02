using System;
using Zenject;

namespace SnakeGame
{
    public sealed class GameOverPresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly GameCycle _gameCycle;

        public GameOverPresenter(IGameUI gameUI, GameCycle gameCycle)
        {
            this._gameUI = gameUI;
            this._gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _gameCycle.OnFinished += OnFinished;
        }

        public void Dispose()
        {
            _gameCycle.OnFinished -= OnFinished;
        }

        private void OnFinished(bool win)
        {
            _gameUI.GameOver(win);
        }
    }
}