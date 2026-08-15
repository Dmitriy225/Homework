using System;
using UnityEngine;

namespace Game.UI
{
    public sealed class HealthStatPresenter :
        IViewContextInit,
        IViewContextEnable,
        IViewContextDisable
    {
        private readonly StatView _view;

        private Health _health;
        private readonly IGameContext _gameContext;

        public HealthStatPresenter(StatView view, IGameContext gameContext)
        {
            _view = view;
            _gameContext = gameContext;
        }

        public void Init(IViewContext context)
        {
            _health = _gameContext.GetCharacter().Value.GetHealth();
        }

        public void Enable(IViewContext context)
        {
            OnHealthChanged();
            _health.OnStateChanged += OnHealthChanged;
        }

        public void Disable(IViewContext context)
        {
            _health.OnStateChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _view.SetText(_health.Current.ToString());
            _view.SetProgress(_health.Percent);
        }
    }
}