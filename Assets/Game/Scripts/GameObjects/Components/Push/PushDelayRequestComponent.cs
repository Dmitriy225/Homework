using System;
using UnityEngine;

namespace Game
{
    public sealed class PushDelayRequestComponent : MonoBehaviour
    {
        public event Action OnPush;

        public bool IsActive
        {
            get
            {
                return _required;
            }
        }

        [SerializeField]
        private PushComponent _pushComponent;

        [SerializeField]
        private CircleDetector _detector;

        [SerializeField]
        private Cooldown _cooldown;

        [SerializeField]
        private Cooldown _delay;

        private Func<bool> _condition;
        private bool _required;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        private void Update()
        {
            _cooldown.Tick(Time.deltaTime);

            if (_required)
            {
                _delay.Tick(Time.deltaTime);
            }

            if (_delay.IsCompleted())
            {
                Push();
                _delay.Reset();
                _cooldown.Reset();
                _required = false;
                OnPush?.Invoke();
            }
        }

        public void RequirePush()
        {
            if (_cooldown.IsCompleted() && _condition.Invoke())
            {
                _required = true;
            }
        }

        private void Push()
        {
            var collider = _detector.Detect();

            if (collider != null && collider.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                _pushComponent.Push(rigidbody);
            }
        }
    }
}