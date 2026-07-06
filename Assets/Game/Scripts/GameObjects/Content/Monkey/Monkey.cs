using System;
using UnityEngine;

namespace Game
{
    public class Monkey : MonoBehaviour
    {
        private HealthComponent _healthComponent;
        private JumpDelayRequestComponent _jumpDelayRequestComponent;
        private GroundedComponent _groundedComponent;
        private LookComponent _lookComponent;
        private CollisionComponent _collisionComponent;
        private PushComponent _pushComponent;

        [SerializeField]
        private CircleDetector _lookCircleDetector;

        [SerializeField]
        private CircleDetector _pushCircleDetector;

        [SerializeField]
        private float _damage;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _jumpDelayRequestComponent = GetComponent<JumpDelayRequestComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _pushComponent = GetComponent<PushComponent>();
        }

        private void Start()
        {
            _jumpDelayRequestComponent.SetCondition(
                () => _healthComponent.IsAlive && _groundedComponent.IsGrounded
            );
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += OnDied;
            _groundedComponent.OnGrounded += OnGrounded;
            _collisionComponent.OnEntered += OnCollisionEntered;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= OnDied;
            _groundedComponent.OnGrounded -= OnGrounded;
            _collisionComponent.OnEntered -= OnCollisionEntered;
        }

        private void FixedUpdate()
        {
            var collider = _lookCircleDetector.Detect();

            if (collider != null)
            {
                _lookComponent.Look(collider.transform);
            }

            _jumpDelayRequestComponent.RequireJump();
        }

        private void OnDied()
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        private void OnGrounded(bool grounded)
        {
            var collider = _pushCircleDetector.Detect();

            if (collider != null && collider.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                _pushComponent.Push(rigidbody);
            }
        }

        private void OnCollisionEntered(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<HealthComponent>(out var health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
}