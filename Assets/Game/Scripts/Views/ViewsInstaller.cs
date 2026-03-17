using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private CurrencyView _moneyView;

        public override void InstallBindings()
        {
            Container
                .Bind<CurrencyView>()
                .FromInstance(_moneyView)
                .AsSingle();
        }
    }
}