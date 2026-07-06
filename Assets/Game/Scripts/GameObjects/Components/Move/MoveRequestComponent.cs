using System;
using UnityEngine;

namespace Game
{
    public sealed class MoveRequestComponent : MonoBehaviour
    {
        public interface IAction
        {
            void Invoke(Vector2 direction);
        }

        public bool IsMoving => Time.time <= _moveTime;

        private float _moveTime;

        [SerializeField]
        private float _moveDuration = 0.1f;

        private Vector2 _direction;
        private IAction _action;
        private Func<bool> _condition;

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void SetAction(IAction action)
        {
            _action = action;
        }

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        private void FixedUpdate()
        {
            if (_direction != Vector2.zero && _condition.Invoke())
            {
                _action.Invoke(_direction);
                _moveTime = Time.time + _moveDuration;
            }
        }
    }
}