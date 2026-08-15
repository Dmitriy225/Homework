using Atomic.Elements;
using UnityEngine;

namespace Game
{
    public sealed class MoveBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IRequest<Vector3> _request;
        private IFunction<Vector3, bool> _condition;
        private IAction<Vector3, float> _action;
        private IEvent<Vector3> _event;
        private ICooldown _postCooldown;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetMoveRequest();
            _condition = entity.GetMoveCondition();
            _action = entity.GetMoveAction();
            _event = entity.GetMoveEvent();
            _postCooldown = entity.GetPostMoveCooldown();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _postCooldown.Tick(deltaTime);

            if (_request.Consume(out Vector3 direction)
                && direction != Vector3.zero
                && _condition.Invoke(direction))
            {
                _action.Invoke(direction, deltaTime);
                _postCooldown.ResetTime();
                _event.Invoke(direction);
            }
        }
    }
}