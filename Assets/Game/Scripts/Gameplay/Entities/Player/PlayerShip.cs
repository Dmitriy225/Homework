using Modules.Utils;
using System;
using UnityEngine;

namespace Game
{
    // +
    public sealed class PlayerShip : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private MovementConfig _movementConfig;

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

        [Header("Bullets")]
        [SerializeField]
        private BulletManager _bulletManager;

        private void Awake()
        {
            _healthComponent.Construct(
                _healthConfig.Health
            );

            _movementComponent.Construct(
                _movementConfig.Speed,
                () => _healthComponent.Exists()
            );

            _fireComponent.Construct(
                () => _healthComponent.Exists()
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

        public void Fire()
        {
            _fireComponent.TryFire();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }

        private void SpawnBullet()
        {
            _bulletManager.Spawn(
                _firePoint.position,
                _firePoint.up,
                _bulletConfig.Speed,
                _bulletConfig.Damage,
                TeamType.Player
            );
        }
    }
}