using Modules.Utils;
using System;
using UnityEngine;

namespace Game
{
    // +
    public sealed class PlayerShip : MonoBehaviour, IMoveable, IAttackable, ITeamer, IAttacker
    {
        public event Action<Vector2> OnMoved
        {
            add { _movementComponent.OnMoved += value; }
            remove { _movementComponent.OnMoved -= value; }
        }

        public event Action<int, int> OnHealthChanged
        {
            add { _healthComponent.OnStateChanged += value; }
            remove { _healthComponent.OnStateChanged -= value; }
        }

        public event Action OnHealthReduced
        {
            add { _healthComponent.OnReduced += value; }
            remove { _healthComponent.OnReduced -= value; }
        }

        public event Action OnFire
        {
            add { _fireComponent.OnFire += value; }
            remove { _fireComponent.OnFire -= value; }
        }

        public event Action OnDied
        {
            add { _healthComponent.OnEmptied += value; }
            remove { _healthComponent.OnEmptied -= value; }
        }

        public Vector2 MoveDirection
        {
            get => _movementComponent.Direction;
            set => _movementComponent.Direction = value;
        }

        public bool IsAlive
        {
            get => _healthComponent.Exists();
        }

        public TeamType Team
        {
            get => TeamType.Player;
        }

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

        public void TakeDamage(int damage)
        {
            _healthComponent.Reduce(damage);
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