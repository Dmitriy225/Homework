using Atomic.Elements;
using UnityEngine;

namespace Game.UI
{
    public sealed class MoveJoystickPresenter : IViewContextInit, IViewContextTick
    {
        private readonly Joystick _joystick;

        private IValue<IGameEntity> _character;
        private readonly IGameContext _gameContext;

        public MoveJoystickPresenter(Joystick joystick, IGameContext gameContext)
        {
            _joystick = joystick;
            _gameContext = gameContext;
        }

        public void Init(IViewContext context)
        {
            _character = _gameContext.GetCharacter();
        }

        public void Tick(IViewContext context, float deltaTime)
        {
            _character.Value.GetMoveRequest().Invoke(new Vector3(_joystick.Direction.x, 0f, _joystick.Direction.y));
        }
    }
}