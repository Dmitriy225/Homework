using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShipView : MonoBehaviour
    {
        [SerializeField]
        private EnemyShip _ship;

        private HealthComponent _healthComponent;
        private FireComponent _fireComponent;

        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private Material _material;

        [SerializeField]
        private DamageViewComponent _damageViewComponent;

        [SerializeField]
        private ParticleSystem _fireVFX;

        private void Awake()
        {
            _healthComponent = _ship.GetComponent<HealthComponent>();
            _fireComponent = _ship.GetComponent<FireComponent>();
            _renderer.material = _material;
        }

        private void OnEnable()
        {
            _healthComponent.OnReduced += _damageViewComponent.AnimateDamage;
            _fireComponent.OnFire += _fireVFX.Play;
        }

        private void OnDisable()
        {
            _healthComponent.OnReduced -= _damageViewComponent.AnimateDamage;
            _fireComponent.OnFire -= _fireVFX.Play;
        }
    }
}