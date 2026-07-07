using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterInputBehaviour : IPlayerContextInit, IPlayerContextTick
    {
        private IValue<IEntity> _character;

        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
        }

        public void Tick(IPlayerContext context, float deltaTime)
        {
            var direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }

            _character.Value.GetMoveRequest().Invoke(direction);
        }
    }
}