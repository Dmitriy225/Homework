using Game.Views;
using Modules.Money;
using Modules.Planets;
using System;
using System.Collections.Generic;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetListPresenter : IInitializable, IDisposable
    {
        private readonly PlanetView[] _views;
        private readonly IPlanet[] _planets;
        private readonly PlanetPresenter.Factory _factory;
        private readonly List<PlanetPresenter> _presenters = new();

        public PlanetListPresenter(
            PlanetView[] views,
            IPlanet[] planets,
            PlanetPresenter.Factory factory
        )
        {
            _views = views;
            _planets = planets;
            _factory = factory;
        }

        public void Initialize()
        {
            for (int i = 0; i < _planets.Length; i++)
            {
                var presenter = _factory.Create(_views[i], _planets[i]);
                _presenters.Add(presenter);
                presenter.Initialize();
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _presenters.Count; i++)
            {
                _presenters[i].Dispose();
            }
        }
    }
}