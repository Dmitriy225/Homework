using Atomic.Elements;

namespace Game
{
    public sealed class FireAnimDrivenBehaviour : IGameEntityInit, IGameEntityDispose, IGameEntityTick
    {
        private const string fireEventKey = "fire_event";
        private IRequest _request;
        private IExpression<bool> _condition;
        private IEvent _animDrivenEvent;
        private IAction _action;
        private IEvent _event;
        private AnimationEvents _animEvents;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetFireRequest();
            _condition = entity.GetFireCondition();
            _animDrivenEvent = entity.GetFireAnimDrivenEvent();
            _action = entity.GetFireAction();
            _event = entity.GetFireEvent();
            _animEvents = entity.GetAnimEvents();
            _animEvents.Subscribe(fireEventKey, OnFireAnimEvent);
        }

        public void Dispose(IGameEntity entity)
        {
            _animEvents.Unsubscribe(fireEventKey, OnFireAnimEvent);
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume() && _condition.Invoke())
            {
                _event.Invoke();
            }
        }

        private void OnFireAnimEvent()
        {
            _action.Invoke();
            _animDrivenEvent.Invoke();
        }
    }
}