using Game.Views;
using Modules.Planets;
using System;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPopupPresenter : IInitializable, IDisposable
    {
        private readonly PlanetPopup _popup;
        private IPlanet _planet;

        public PlanetPopupPresenter(PlanetPopup popup)
        {
            _popup = popup;
        }

        public void Initialize()
        {
            _popup.OnCloseClicked += Hide;
            _popup.OnUpgradeClicked += OnUpgradeClicked;
        }

        public void Dispose()
        {
            _popup.OnCloseClicked -= Hide;
            _popup.OnUpgradeClicked -= OnUpgradeClicked;
        }

        public void Show(IPlanet planet)
        {
            if (planet != null)
            {
                _planet = planet;
                UpdateState();
                _popup.Show();
                _planet.OnPopulationChanged += OnPopulationChanged;
                _planet.OnUpgraded += OnUpgraded;
                _planet.OnIncomeChanged += OnIncomeChanged;
            }
        }

        private void Hide()
        {
            _planet.OnPopulationChanged -= OnPopulationChanged;
            _planet.OnUpgraded -= OnUpgraded;
            _planet.OnIncomeChanged -= OnIncomeChanged;
            _popup.Hide();
        }

        private void UpdateState()
        {
            _popup.SetIcon(_planet.GetIcon(true));
            OnPopulationChanged(_planet.Population);
            OnUpgraded(_planet.Level);
            OnIncomeChanged(_planet.MinuteIncome);
        }

        private void OnUpgradeClicked()
        {
            _planet.Upgrade();
        }

        private void OnPopulationChanged(int population)
        {
            _popup.SetPopulation(string.Format("Population: {0}", population));
        }

        private void OnUpgraded(int level)
        {
            _popup.SetLevel(string.Format("Level: {0}/{1}", level, _planet.MaxLevel));
            _popup.SetUpgradeButtonInteractable(_planet.CanUpgrade);

            if (!_planet.IsMaxLevel)
            {
                _popup.SetUpgradeButtonText("Upgrade");
                _popup.SetPriceActive(true);
                _popup.SetPrice(_planet.Price.ToString());
                return;
            }

            _popup.SetUpgradeButtonText("Max Level");
                _popup.SetPriceActive(false);
        }

        private void OnIncomeChanged(int income)
        {
            _popup.SetIncome(string.Format("Income: {0}$", income));
        }
    }
}