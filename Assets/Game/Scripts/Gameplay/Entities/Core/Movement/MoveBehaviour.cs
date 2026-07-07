using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class MoveBehaviour : IEntityInit, IEntityFixedTick
    {
        private IRequest<Vector3> _request;
        private IFunction<Vector3, bool> _condition;
        private IAction<Vector3, float> _action;
        private IEvent<Vector3> _event;

        public void Init(IEntity entity)
        {
            _request = entity.GetMoveRequest();
            _condition = entity.GetMoveCondition();
            _action = entity.GetMoveAction();
            _event = entity.GetMoveEvent();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if (_request.Consume(out Vector3 direction)
                && direction != Vector3.zero
                && _condition.Invoke(direction))
            {
                _action.Invoke(direction, deltaTime);
                _event.Invoke(direction);
            }
        }
    }
}