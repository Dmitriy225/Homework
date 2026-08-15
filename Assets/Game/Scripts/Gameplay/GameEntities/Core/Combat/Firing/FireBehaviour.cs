using Atomic.Elements;

namespace Game
{
    public sealed class FireBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest _request;
        private IExpression<bool> _condition;
        private IAction _action;
        private IEvent _event;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetFireRequest();
            _condition = entity.GetFireCondition();
            _action = entity.GetFireAction();
            _event = entity.GetFireEvent();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume() && _condition.Invoke())
            {
                _action.Invoke();
                _event.Invoke();
            }
        }
    }
}