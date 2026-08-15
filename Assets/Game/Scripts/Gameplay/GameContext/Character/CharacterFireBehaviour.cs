using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterFireBehaviour : IGameContextInit, IGameContextTick
    {
        private IValue<IGameEntity> _character;

        public void Init(IGameContext context)
        {
            _character = context.GetCharacter();
        }

        public void Tick(IGameContext context, float deltaTime)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                _character.Value.GetFireRequest().Invoke();
            }

        }
    }
}