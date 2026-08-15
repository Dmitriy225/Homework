using System;
using UnityEngine;

namespace Game
{
    public sealed class IncreaseScoreBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private Health _health;
        private readonly IGameContext _gameContext;

        public IncreaseScoreBehaviour(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IGameEntity entity)
        {
            _health = entity.GetHealth();
            _health.OnEmptied += OnHealthEmptied;
        }

        public void Dispose(IGameEntity entity)
        {
            _health.OnEmptied -= OnHealthEmptied;
        }

        private void OnHealthEmptied()
        {
            _gameContext.GetScore().Value++;
        }
    }
}