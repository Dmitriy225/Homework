using System;
using UnityEngine;

namespace Game
{
    public sealed class FireComponent : MonoBehaviour
    {
        public event Action OnFire;

        [SerializeField]
        private float _fireCooldown = 0.25f;

        [SerializeField]
        private BulletConfig _bulletConfig;

        private Transform _firePoint;
        private Cooldown _cooldown;
        private BulletManager _bulletManager;
        private TeamType _team;
        private Func<bool> _condition;

        public void Construct(
            BulletManager bulletManager,
            Transform firePoint,
            TeamType team,
            Func<bool> condition)
        {
            _bulletManager = bulletManager;
            _firePoint = firePoint;
            _team = team;
            _condition = condition;
            _cooldown = new Cooldown(_fireCooldown);
        }

        private void Update()
        {
            _cooldown.Tick(Time.deltaTime);
        }

        public void TryFire(Vector2 direction)
        {
            if (!_cooldown.IsCompleted() || !_condition.Invoke())
            {
                return;
            }

            _bulletManager.Spawn(
                _firePoint.position,
                direction,
                _bulletConfig.Speed,
                _bulletConfig.Damage,
                _team
            );

            OnFire?.Invoke();
            _cooldown.Reset();
        }
    }
}