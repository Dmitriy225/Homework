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
        private MovementComponent _movementComponent;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private float _stoppingDistance = 0.25f;

        private Vector2 _destination;
        private bool _isReached;

        public void FixedUpdate()
        {
            Vector2 distance = _destination - (Vector2)_transform.position;
            _isReached = distance.sqrMagnitude <= _stoppingDistance * _stoppingDistance;

            _movementComponent.Direction = _isReached ? Vector3.zero : distance.normalized;
        }
    }
}