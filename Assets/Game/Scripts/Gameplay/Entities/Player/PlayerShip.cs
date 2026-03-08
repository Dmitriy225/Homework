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
                _bulletManager,
                _firePoint,
                TeamType.Player,
                () => _healthComponent.Exists()
            );
        }

        private void OnEnable()
        {
            _healthComponent.OnEmptied += Disable;
        }

        private void OnDisable()
        {
            _healthComponent.OnEmptied -= Disable;
        }

        public void Fire()
        {
            _fireComponent.TryFire(Vector2.up);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}