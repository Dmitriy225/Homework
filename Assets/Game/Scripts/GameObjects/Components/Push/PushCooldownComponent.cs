using System;
using UnityEngine;

namespace Game
{
    public sealed class PushCooldownComponent : MonoBehaviour
    {
        public event Action OnPush;

        [SerializeField]
        private PushComponent _pushComponent;

        [SerializeField]
        private Cooldown _cooldown;

        private Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        private void Update()
        {
            _cooldown.Tick(Time.deltaTime);
        }

        public void Push(Rigidbody2D rigidbody)
        {
            if (_cooldown.IsCompleted() && _condition.Invoke())
            {
                _pushComponent.Push(rigidbody);
                _cooldown.Reset();
                OnPush?.Invoke();
            }
        }
    }
}