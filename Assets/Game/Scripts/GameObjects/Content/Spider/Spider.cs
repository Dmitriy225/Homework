using Game;
using System;
using UnityEngine;

namespace Game
{
    public sealed class Spider : MonoBehaviour, MoveRequestComponent.IAction
    {
        private HealthComponent _healthComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;
        private GroundedComponent _groundedComponent;
        private CollisionComponent _collisionComponent;
        private LookComponent _lookComponent;
        private PatrolComponent _patrolComponent;
        private PushCooldownComponent _pushComponent;

        [SerializeField]
        private float _damage;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveTransformComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _patrolComponent = GetComponent<PatrolComponent>();
            _pushComponent = GetComponent<PushCooldownComponent>();
        }

        private void Start()
        {
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(() => _healthComponent.IsAlive);
            _patrolComponent.SetCondition(() => _healthComponent.IsAlive);
            _pushComponent.SetCondition(() => _healthComponent.IsAlive && _groundedComponent);
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += OnDied;
            _collisionComponent.OnEntered += OnCollisionEntered;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= OnDied;
            _collisionComponent.OnEntered -= OnCollisionEntered;
        }

        private void FixedUpdate()
        {
            _moveRequestComponent.SetDirection(_patrolComponent.Direction);
        }

        public void Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
            _lookComponent.Look(direction.x);
        }

        private void OnDied()
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        private void OnCollisionEntered(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<HealthComponent>(out var health))
            {
                health.TakeDamage(_damage);

                if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody))
                {
                    _pushComponent.Push(rigidbody);
                }
            }
        }
    }
}