using System;
using UnityEngine;

namespace Game
{
    public sealed class JumpCooldownRequestComponent : MonoBehaviour
    {
        public event Action OnJump;

        [SerializeField]
        private JumpComponent _jumpComponent;

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

        public void RequireJump()
        {
            //if (_cooldown.IsCompleted())
            //{
            //    Debug.Log("COOLDOWN COMPLETED");
            //}
            if (_cooldown.IsCompleted() && _condition.Invoke())
            {
                Debug.Log("Jump");
                _jumpComponent.Jump();
                _cooldown.Reset();
                OnJump?.Invoke();
            }
        }
    }
}