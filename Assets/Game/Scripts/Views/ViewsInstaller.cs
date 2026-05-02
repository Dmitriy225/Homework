using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private CurrencyView _moneyView;

        [SerializeField]
        private PlanetView[] _planetViews;

        [SerializeField]
        private PlanetPopup _planetPopup;

        public override void InstallBindings()
        {
            Container
                .Bind<CurrencyView>()
                .FromInstance(_moneyView)
                .AsSingle();

            foreach (var planetView in _planetViews)
            {
                Container
                    .Bind<PlanetView>()
                    .FromInstance(planetView)
                    .AsCached();
            }

            Container
                .Bind<PlanetPopup>()
                .FromInstance(_planetPopup)
                .AsSingle();
        }
    }
}