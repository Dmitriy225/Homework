using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class FollowTargetBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IValue<IGameEntity> _target;
        private IValue<Vector3> _position;
        private IRequest<Vector3> _moveRequest;

        public void Init(IGameEntity entity)
        {
            _target = entity.GetTarget();
            _position = entity.GetPosition();
            _moveRequest = entity.GetMoveRequest();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            var target = _target.Value;

            if (target == null)
            {
                return;
            }

            var delta = target.GetPosition().Value - _position.Value;
            delta.y = 0;
            _moveRequest.Invoke(delta);
        }
    }
}