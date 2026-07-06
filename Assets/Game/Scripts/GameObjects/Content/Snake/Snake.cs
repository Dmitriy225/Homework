using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class Snake : MonoBehaviour, MoveRequestComponent.IAction
    {
        private HealthComponent _healthComponent;
        private PushCooldownComponent _pushComponent;
        private FollowTargetComponent _followTargetComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;
        private LookComponent _lookComponent;
        private CollisionComponent _collisionComponent;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private float _detectRadius;

        [SerializeField]
        private LayerMask _characterLayerMask;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _pushComponent = GetComponent<PushCooldownComponent>();
            _followTargetComponent = GetComponent<FollowTargetComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveTransformComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
        }

        private void Start()
        {
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(() => _healthComponent.IsAlive);
            _pushComponent.SetCondition(() => _healthComponent.IsAlive);
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

        private void OnDied()
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        private void FixedUpdate()
        {
            var target = Physics2D.OverlapCircle(transform.position, _detectRadius, _characterLayerMask);

            if (target != null)
            {
                _followTargetComponent.SetTarget(target.transform);
            }
            else
            {
                _followTargetComponent.SetTarget(null);
            }
        }

        public void Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
            _lookComponent.Look(direction.x);
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