using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class AimBehaviour :
        IGameEntityInit,
        IGameEntityTick
    {
        private IRequest<Vector3> _request;
        private IExpression<Vector3, bool> _condition;
        private IAction<Vector3, float> _action;
        private IEvent<Vector3> _event;
        private ITimer _postTimer;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetAimRequest();
            _condition = entity.GetAimCondition();
            _action = entity.GetAimAction();
            _event = entity.GetAimEvent();
            _postTimer = entity.GetPostAimTimer();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _postTimer.Tick(deltaTime);

            if (_request.Consume(out Vector3 direction) && direction != Vector3.zero && _condition.Invoke(direction))
            {
                _postTimer.Start();
                _postTimer.ResetTime();
                _action.Invoke(direction, deltaTime);
                _event.Invoke(direction);
            }
        }
    }
}