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

        [SerializeField]
        private BulletConfig _bulletConfig;

        private PlayerShip _target;
        private BulletManager _bulletManager;

        public void Construct(
            BulletManager bulletManager,
            PlayerShip target,
            Vector2 destination)
        {
            _bulletManager = bulletManager;
            _target = target;
            _destinationComponent.Destination = destination;
        }

        private void Awake()
        {
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
                () =>
                    _healthComponent.Exists()
                    && _destinationComponent.IsReached
                    && _target != null
                    && _target.IsAlive
            );
        }

        private void OnEnable()
        {
            _healthComponent.OnEmptied += Disable;
            _fireComponent.OnFire += SpawnBullet;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= Disable;
            _fireComponent.OnFire -= SpawnBullet;
        }

        private void Update()
        {
            _fireComponent.TryFire();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }

        private void SpawnBullet()
        {
            Vector2 position = _firePoint.position;
            Vector2 target = _target.transform.position;
            Vector2 direction = (target - position).normalized;

            _bulletManager.Spawn(
                position,
                direction,
                _bulletConfig.Speed,
                _bulletConfig.Damage,
                TeamType.Enemy
            );
        }
    }
}