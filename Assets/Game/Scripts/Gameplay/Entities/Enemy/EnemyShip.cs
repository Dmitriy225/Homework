using Mono.Cecil;
using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShip : MonoBehaviour
    {
        public event Action<EnemyShip> OnDied;

        [Header("Movement")]
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private MovementConfig _movementConfig;

        [Header("Destination")]
        [SerializeField]
        private DestinationComponent _destinationComponent;

        [Header("Health")]
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private HealthConfig _healthConfig;

        [Header("Combat")]
        [SerializeField]
        private FireComponent _fireComponent;

        private PlayerShip _target;

        public void Construct(BulletManager bulletManager, PlayerShip target)
        {
            _target = target;

            _healthComponent.Construct(
                _healthConfig.Health
            );

            _movementComponent.Construct(
                _movementConfig.Speed,
                () =>
                    _healthComponent.Exists()
                    && !_destinationComponent.IsReached
            );

            _fireComponent.Construct(
                bulletManager,
                TeamType.Enemy,
                () =>
                    _healthComponent.Exists()
                    && _destinationComponent.IsReached
                    && _target != null
                    && _target.GetComponent<HealthComponent>().Exists()
            );
        }

        public void SetDestination(Vector2 destination)
        {
            _destinationComponent.Destination = destination;
        }

        private void OnEnable()
        {
            _healthComponent.OnEmptied += OnHealthEmptied;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= OnHealthEmptied;
        }

        private void Update()
        {
            _fireComponent.TryFire(
                ((Vector2)_target.transform.position - _fireComponent.PointPosition).normalized
            );
        }

        private void OnHealthEmptied()
        {
            OnDied?.Invoke(this);
        }
    }
}