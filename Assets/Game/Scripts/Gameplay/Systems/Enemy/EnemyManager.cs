using System;
using System.Collections;
using Modules.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    // +
    public sealed class EnemyManager : MonoBehaviour
    {
        public event Action<int> OnEnemyDestroyed;

        public int DestroyedEnemies
        {
            get => _destroyedEnemies;
        }

        [Header("Spawn")]
        [SerializeField]
        private float _minSpawnCooldown = 2;

        [SerializeField]
        private float _maxSpawnCooldown = 3;

        [Header("Pool")]
        [SerializeField]
        private Pool<EnemyShip> _pool;
        
        [Header("Points")]
        [SerializeField]
        private Transform[] _spawnPositions;
        
        [SerializeField]
        private Transform[] _attackPositions;

        [Header("Bullets")]
        [SerializeField]
        private BulletManager _bulletManager;

        [Header("Target")]
        [SerializeField]
        private PlayerShip _target;

        private int _spawnIndex;
        private int _attackIndex;
        private int _destroyedEnemies;
        private Cooldown _cooldown;
        
        private void Awake()
        {
            _spawnPositions.Shuffle();
            _attackPositions.Shuffle();
            _cooldown = new Cooldown(NextSpawnDuration());
        }

        private void FixedUpdate()
        {
            _cooldown.Tick(Time.fixedDeltaTime);

            if (!_cooldown.IsCompleted() || !_target.GetComponent<HealthComponent>().Exists()) // TODO: Убрать GetComponent
            {
                return;
            }

            var enemy = _pool.Rent();

            enemy.Construct(
                _bulletManager,
                _target,
                NextDestination()
            );

            enemy.transform.position = NextSpawnPosition();
            _cooldown.SetDuration(NextSpawnDuration());
            _cooldown.Reset();
        }

        public void Despawn(EnemyShip enemy)
        {
            _destroyedEnemies++;
            OnEnemyDestroyed?.Invoke(_destroyedEnemies);
            _pool.Return(enemy);
        }

        private float NextSpawnDuration()
        {
            return Random.Range(_minSpawnCooldown, _maxSpawnCooldown);
        }
        
        private Vector3 NextSpawnPosition()
        {
            if (_spawnIndex >= _spawnPositions.Length)
            {
                _spawnPositions.Shuffle();
                _spawnIndex = 0;
            }

            return _spawnPositions[_spawnIndex++].position;
        }

        private Vector3 NextDestination()
        {
            if (_attackIndex >= _attackPositions.Length)
            {
                _attackPositions.Shuffle();
                _attackIndex = 0;
            }

            return _attackPositions[_attackIndex++].position;
        }
    }
}