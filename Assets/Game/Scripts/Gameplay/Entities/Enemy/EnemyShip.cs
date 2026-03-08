using Mono.Cecil;
using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShip : MonoBehaviour
    {
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

        [SerializeField]
        private Transform _firePoint;

        private PlayerShip _target;

        public void Construct(
            BulletManager bulletManager,
            PlayerShip target)
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
                _firePoint,
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
            _healthComponent.OnEmptied += Disable;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= Disable;
        }

        private void Update()
        {
            _fireComponent.TryFire(
                (_target.transform.position - _firePoint.position).normalized
            );
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}