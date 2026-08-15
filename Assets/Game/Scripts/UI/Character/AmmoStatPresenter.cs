using Atomic.Elements;

namespace Game.UI
{
    public sealed class AmmoStatPresenter :
        IViewContextInit,
        IViewContextEnable,
        IViewContextDisable
    {
        private readonly StatView _view;

        private IReactiveValue<int> _ammo;
        private readonly IGameContext _gameContext;

        public AmmoStatPresenter(StatView view, IGameContext gameContext)
        {
            _view = view;
            _gameContext = gameContext;
        }

        public void Init(IViewContext context)
        {
            _ammo = _gameContext.GetCharacter().Value.GetWeapon().Value.GetAmmo();
        }

        public void Enable(IViewContext context)
        {
            _ammo.Observe(OnAmmoChanged);
        }

        public void Disable(IViewContext context)
        {
            _ammo.Unsubscribe(OnAmmoChanged);
        }

        private void OnAmmoChanged(int value)
        {
            _view.SetText(value.ToString());
        }
    }
}