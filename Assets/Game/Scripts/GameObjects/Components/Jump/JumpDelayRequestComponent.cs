using System;
using UnityEngine;

namespace Game
{
    public sealed class JumpDelayRequestComponent : MonoBehaviour
    {
        public event Action OnJump;

        [SerializeField]
        private JumpComponent _jumpComponent;

        [SerializeField]
        private Cooldown _cooldown;

        [SerializeField]
        private Cooldown _delay;

        private Func<bool> _condition;
        private bool _required = false;

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
                _jumpComponent.Jump();
                _cooldown.Reset();
                _delay.Reset();
                _required = false;
                OnJump?.Invoke();
            }
        }

        public void RequireJump()
        {
            if (_cooldown.IsCompleted() && _condition.Invoke())
            {
                _required = true;
            }
        }
    }
}