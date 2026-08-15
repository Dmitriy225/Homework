using Atomic.Elements;
using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Game.UI
{
    public sealed class ScorePresenter : IViewContextEnable, IViewContextDisable
    {
        private readonly TMP_Text _score;
        private readonly IGameContext _gameContext;

        public ScorePresenter(TMP_Text score, IGameContext gameContext)
        {
            _score = score;
            _gameContext = gameContext;
        }

        public void Enable(IViewContext entity)
        {
            OnScoreChanged(_gameContext.GetScore().Value);
            _gameContext.GetScore().Subscribe(OnScoreChanged);
        }

        public void Disable(IViewContext entity)
        {
            _gameContext.GetScore().Unsubscribe(OnScoreChanged);
        }

        private void OnScoreChanged(int value)
        {
            _score.text = value.ToString();
        }
    }
}