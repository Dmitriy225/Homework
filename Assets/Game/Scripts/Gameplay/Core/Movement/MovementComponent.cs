using System;
using UnityEngine;

namespace Game
{
    public sealed class MovementComponent : MonoBehaviour
    {
        public event Action<Vector2> OnMoved;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;
        private Vector2 _direction;
        private Func<bool> _condition;

        public void Construct(float speed, Func<bool> condition)
        {
            _speed = speed;
            _condition = condition;
        }

        private void FixedUpdate()
        {
            if (!_condition.Invoke())
            {
                return;
            }

            Vector2 newPosition = _rigidbody.position + _direction.normalized * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
            OnMoved?.Invoke(_direction);
        }
    }
}