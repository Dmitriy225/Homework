using System;
using System.Collections.Generic;
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
        private PlayerShip _target;

        [SerializeField]
        private PositionShuffler _spawnPositionShuffler;

        [SerializeField]
        private PositionShuffler _attackPositionShuffler;

        private int _destroyedEnemies;
        private List<EnemyShip> _enemies = new();

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
            enemy.OnDied += Despawn;

            _spawnCooldown.Restart();
        }

        public void Despawn(EnemyShip enemy)
        {
            enemy.OnDied -= Despawn;
            _destroyedEnemies++;
            OnEnemyDestroyed?.Invoke(_destroyedEnemies);
            _pool.Return(enemy);
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].OnDied -= Despawn;
            }
        }
    }
}