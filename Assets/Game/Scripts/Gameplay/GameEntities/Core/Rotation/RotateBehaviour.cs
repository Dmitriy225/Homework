using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class RotateBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _request;
        private IFunction<Vector3, bool> _condition;
        private IAction<Vector3, float> _action;
        private IEvent<Vector3> _event;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetRotateRequest();
            _condition = entity.GetRotateCondition();
            _action = entity.GetRotateAction();
            _event = entity.GetRotateEvent();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
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