using System;
using UnityEngine;

namespace Game
{
    public sealed class PatrolComponent : MonoBehaviour
    {
        private const float STOP_DISTANCE = 0.05f;

        public interface IAction
        {
            void Invoke(Vector2 direction);
        }

        public Vector2 Direction { get; private set; }
        
        [SerializeField]
        private Transform _firstPoint;

        [SerializeField]
        private Transform _secondPoint;

        private Transform _currentPoint;
        private Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        private void Start()
        {
            _currentPoint = _firstPoint;    
        }

        private void FixedUpdate()
        {
            if (_condition.Invoke())
            {
                if (Vector2.Distance(transform.position, _currentPoint.position) < STOP_DISTANCE)
                {
                    SwitchTarget();
                }

                Direction = (_currentPoint.position - transform.position).normalized;
            }
        }

        private void SwitchTarget()
        {
            _currentPoint = _currentPoint == _firstPoint ? _secondPoint : _firstPoint;
        }
    }
}