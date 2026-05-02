using Game.Views;
using Modules.Money;
using Modules.Planets;
using System;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly PlanetView _view;
        private readonly IPlanet _planet;
        private readonly PlanetPopupPresenter _planetPopupPresenter;

        public PlanetPresenter(
            PlanetView view,
            IPlanet planet,
            PlanetPopupPresenter planetPopupPresenter
        )
        {
            _view = view;
            _planet = planet;
            _planetPopupPresenter = planetPopupPresenter;
        }

        public void Initialize()
        {
            _view.SetPrice(_planet.Price.ToString());
            OnUnlocked();
            OnIncomeReady(_planet.IsIncomeReady);

            _view.OnClicked += OnClicked;
            _view.OnHold += OnHold;
            _planet.OnUnlocked += OnUnlocked;
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnIncomeReady += OnIncomeReady;
        }

        public void Dispose()
        {
            _view.OnClicked -= OnClicked;
            _view.OnHold -= OnHold;
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnIncomeReady;
        }

        private void OnClicked()
        {
            if (_planet.IsUnlocked)
            {
                _planet.GatherIncome();
            }
            else
            {
                _planet.Unlock();
            }
        }

        private void OnHold()
        {
            if (_planet.IsUnlocked)
                _planetPopupPresenter.Show(_planet);
        }

        private void OnUnlocked()
        {
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetLockActive(!_planet.IsUnlocked);
            _view.SetCoinActive(_planet.IsIncomeReady);
            _view.SetIncomeActive(!_planet.IsIncomeReady);
        }

        private void OnIncomeTimeChanged(float remainingTime)
        {
            var timeSpan = TimeSpan.FromSeconds(remainingTime);
            _view.SetIncomeProgress(_planet.IncomeProgress);
            _view.SetIncomeTime(string.Format("{0}m:{1}s", timeSpan.Minutes, timeSpan.Seconds));
        }

        private void OnIncomeReady(bool ready)
        {
            _view.SetCoinActive(ready && _planet.IsUnlocked);
            _view.SetIncomeActive(!ready && _planet.IsUnlocked);
        }

        public sealed class Factory : PlaceholderFactory<PlanetView, IPlanet, PlanetPresenter>
        {

        }
    }
}