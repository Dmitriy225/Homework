using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShipView : MonoBehaviour
    {
        [SerializeField]
        private EnemyShip _ship;

        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private Material _material;

        [SerializeField]
        private DamageViewComponent _damageViewComponent;

        [SerializeField]
        private DeadViewComponent _deadViewComponent;

        [SerializeField]
        private MovementViewComponent _movementViewComponent;

        [SerializeField]
        private ParticleSystem _fireVFX;

        private void Awake()
        {
            _renderer.material = _material;
        }

        private void OnEnable()
        {
            _ship.OnMoved += OnShipMoved;
            _ship.OnHealthReduced += _damageViewComponent.AnimateDamage;
            _ship.OnDied += _deadViewComponent.InstantiateEffect;
            _ship.OnFire += _fireVFX.Play;
        }

        private void OnDisable()
        {
            _ship.OnMoved -= OnShipMoved;
            _ship.OnHealthReduced -= _damageViewComponent.AnimateDamage;
            _ship.OnDied -= _deadViewComponent.InstantiateEffect;
            _ship.OnFire -= _fireVFX.Play;
        }

        private void LateUpdate()
        {
            _movementViewComponent.AnimateMovement(Time.deltaTime);
        }

        private void OnShipMoved(Vector2 direction)
        {
            _movementViewComponent.Direction = direction;
        }
    }
}