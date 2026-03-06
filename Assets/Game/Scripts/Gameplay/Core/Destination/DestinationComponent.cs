using UnityEngine;

namespace Game
{
    public sealed class DestinationComponent : MonoBehaviour
    {
        public Vector2 Destination
        {
            get => _destination;
            set => _destination = value;
        }

        public bool IsReached
        {
            get => _isReached;
        }

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private float _stoppingDistance = 0.25f;

        private IMoveable _moveable;
        private Vector2 _destination;
        private bool _isReached;

        public void Construct(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public void FixedUpdate()
        {
            Vector2 distance = _destination - (Vector2)_transform.position;
            _isReached = distance.sqrMagnitude <= _stoppingDistance * _stoppingDistance;

            _moveable.MoveDirection = _isReached ? Vector3.zero : distance.normalized;
        }
    }
}