using System;
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
        private SpawnCooldown _spawnCooldown;

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
        
        private void Awake()
        {
            _spawnPositions.Shuffle();
            _attackPositions.Shuffle();
        }

        private void FixedUpdate()
        {
            if (!_spawnCooldown.IsCompleted() || !_target.GetComponent<HealthComponent>().Exists()) // TODO: Убрать GetComponent
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
            _spawnCooldown.Restart();
        }

        public void Despawn(EnemyShip enemy)
        {
            _destroyedEnemies++;
            OnEnemyDestroyed?.Invoke(_destroyedEnemies);
            _pool.Return(enemy);
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