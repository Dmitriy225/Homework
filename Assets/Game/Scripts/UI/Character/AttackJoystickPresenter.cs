using Atomic.Elements;
using System;
using UnityEngine;

namespace Game.UI
{
    public sealed class AttackJoystickPresenter : IViewContextInit, IViewContextTick
    {
        private readonly Joystick _joystick;

        private IValue<IGameEntity> _character;
        private readonly IGameContext _gameContext;

        public AttackJoystickPresenter(Joystick joystick, IGameContext gameContext)
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
            _character.Value.GetAimRequest().Invoke(new Vector3(_joystick.Direction.x, 0f, _joystick.Direction.y));
        }
    }
}