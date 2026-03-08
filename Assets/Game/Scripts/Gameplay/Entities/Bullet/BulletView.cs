using System;
using UnityEngine;

namespace Game
{
    public sealed class BulletView : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bullet;

        [SerializeField]
        private TeamComponent _teamComponent;

        [SerializeField]
        private Transform _vfxContainer;

        [SerializeField]
        private BulletViewConfig _viewConfig;

        [SerializeField]
        private ParticleSystem _currentProjectileVfx;

        private void OnEnable()
        {
            OnTeamChanged(_teamComponent.Team);
            _bullet.OnHit += OnHit;
            _teamComponent.OnTeamChanged += OnTeamChanged;
        }

        private void OnDisable()
        {
            _bullet.OnHit -= OnHit;
            _teamComponent.OnTeamChanged -= OnTeamChanged;
        }

        private void OnHit()
        {
            GameObject prefab = _viewConfig.ExplosionVFX;
            Instantiate(
                prefab,
                _bullet.GetComponent<Transform>().position,
                prefab.transform.rotation
            );
        }

        private void OnTeamChanged(TeamType team)
        {
            if (_currentProjectileVfx != null)
            {
                Destroy(_currentProjectileVfx.gameObject);
                _currentProjectileVfx = null;
            }

            _currentProjectileVfx = Instantiate(_viewConfig.GetVfxPrefabOrDefault(team), _vfxContainer);
        }
    }
}