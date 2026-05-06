using Game.Views;
using Modules.Money;
using Modules.Planets;
using Modules.UI;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly PlanetView _view;
        private readonly CurrencyView _currencyView;
        private readonly ParticleAnimator _particleAnimator;
        private readonly IPlanet _planet;
        private readonly IMoneyStorage _moneyStorage;
        private readonly PlanetPopupPresenter _planetPopupPresenter;

        public PlanetPresenter(
            PlanetView view,
            CurrencyView currencyView,
            ParticleAnimator particleAnimator,
            IPlanet planet,
            IMoneyStorage moneyStorage,
            PlanetPopupPresenter planetPopupPresenter
        )
        {
            _view = view;
            _currencyView = currencyView;
            _particleAnimator = particleAnimator;
            _planet = planet;
            _moneyStorage = moneyStorage;
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
            _planet.OnGathered += OnGathered;
        }

        public void Dispose()
        {
            _view.OnClicked -= OnClicked;
            _view.OnHold -= OnHold;
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnGathered -= OnGathered;
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

        private void OnGathered(int value)
        {
            _particleAnimator.Emit(
                _view.transform.position,
                _currencyView.transform.position,
                onFinished: () => _currencyView.AddValue(_moneyStorage.Money - value, value)
            );
        }

        public sealed class Factory : PlaceholderFactory<PlanetView, IPlanet, PlanetPresenter>
        {

        }
    }
}