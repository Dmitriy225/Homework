using Game.Views;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/New PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        [SerializeField]
        private PlanetCatalog _planetCatalog;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<MoneyPresenter>()
                .AsSingle();

            Container
                .BindFactory<PlanetView, IPlanet, PlanetPresenter, PlanetPresenter.Factory>()
                .AsSingle();

            Container
                .BindInterfacesTo<PlanetListPresenter>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
                .AsSingle();
        }
    }
}