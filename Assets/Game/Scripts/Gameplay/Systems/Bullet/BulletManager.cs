using Modules.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    // +
    public sealed class BulletManager : MonoBehaviour
    {
        [Serializable]
        public struct TeamLayerData
        {
            public TeamType team;
            public LayerMask layer;
        }

        [SerializeField]
        private TransformBounds _levelBounds;

        [SerializeField]
        private Pool<Bullet> _pool;

        [SerializeField]
        private TeamLayerData[] _layers;

        private readonly List<Bullet> _bullets = new();

        private void FixedUpdate()
        {
            for (int i = _bullets.Count - 1; i >= 0; i--)
            {
                var bullet = _bullets[i];

                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    _bullets.RemoveAt(i);
                    _pool.Return(bullet);
                }
            }
        }

        public void Spawn(
            Vector2 position,
            Vector2 direction,
            float speed,
            int damage,
            TeamType team)
        {
            var bullet = _pool.Rent();

            bullet.SetArgs(
                new Bullet.Args
                {
                    speed = speed,
                    direction = direction,
                    damage = damage,
                    team = team
                }
            );

            bullet.transform.SetPositionAndRotation(
                position,
                Quaternion.LookRotation(direction, Vector3.forward)
            );

            bullet.gameObject.layer = GetLayerOrDefault(team);

            _bullets.Add(bullet);
            bullet.OnDied += Despawn;
        }

        private void Despawn(Bullet bullet)
        {
            bullet.OnDied -= Despawn;
            _bullets.Remove(bullet);
            _pool.Return(bullet);
        }

        private int GetLayerOrDefault(TeamType team)
        {
            for (int i = 0; i < _layers.Length; i++)
            {
                if (_layers[i].team == team)
                {
                    LayerMask mask = _layers[i].layer;
                    return (int)Mathf.Log(mask.value, 2);
                }
            }

            return default;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].OnDied -= Despawn;
            }
        }
    }
}