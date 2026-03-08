using System;
using UnityEngine;

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

        [SerializeField]
        private SpawnCooldown _spawnCooldown;

        [SerializeField]
        private EnemyPool _pool;

        [SerializeField]
        private BulletManager _bulletManager;

        [SerializeField]
        private PlayerShip _target;

        [SerializeField]
        private PositionShuffler _spawnPositionShuffler;

        [SerializeField]
        private PositionShuffler _attackPositionShuffler;

        private int _destroyedEnemies;

        private void Awake()
        {
            _spawnPositionShuffler.Shuffle();
            _attackPositionShuffler.Shuffle();
        }

        private void FixedUpdate()
        {
            if (!_spawnCooldown.IsCompleted() || !_target.GetComponent<HealthComponent>().Exists()) // TODO: Убрать GetComponent
            {
                return;
            }

            var enemy = _pool.Rent();
            enemy.SetDestination(_attackPositionShuffler.NextPosition());
            enemy.transform.position = _spawnPositionShuffler.NextPosition();

            _spawnCooldown.Restart();
        }

        public void Despawn(EnemyShip enemy)
        {
            _destroyedEnemies++;
            OnEnemyDestroyed?.Invoke(_destroyedEnemies);
            _pool.Return(enemy);
        }
    }
}