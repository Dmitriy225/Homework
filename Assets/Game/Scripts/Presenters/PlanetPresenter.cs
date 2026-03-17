using Game.Views;
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

        public PlanetPresenter(PlanetView view, IPlanet planet)
        {
            _view = view;
            _planet = planet;
        }

        public void Initialize()
        {
            UpdateLockState();
            _planet.OnUnlocked += UpdateLockState;
        }

        public void Dispose()
        {
            _planet.OnUnlocked -= UpdateLockState;
        }

        private void UpdateLockState()
        {
            _view.SetImageIcon(_planet.GetIcon(_planet.IsUnlocked));
        }
    }
}