using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShipView : MonoBehaviour
    {
        [SerializeField]
        private EnemyShip _ship;

        private MovementComponent _movementComponent;
        private HealthComponent _healthComponent;
        private FireComponent _fireComponent;

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
            _movementComponent = _ship.GetComponent<MovementComponent>();
            _healthComponent = _ship.GetComponent<HealthComponent>();
            _fireComponent = _ship.GetComponent<FireComponent>();
            _renderer.material = _material;
        }

        private void OnEnable()
        {
            _movementComponent.OnMoved += OnShipMoved;
            _healthComponent.OnReduced += _damageViewComponent.AnimateDamage;
            _healthComponent.OnEmptied += _deadViewComponent.InstantiateEffect;
            _fireComponent.OnFire += _fireVFX.Play;
        }

        private void OnDisable()
        {
            _movementComponent.OnMoved -= OnShipMoved;
            _healthComponent.OnReduced -= _damageViewComponent.AnimateDamage;
            _healthComponent.OnEmptied -= _deadViewComponent.InstantiateEffect;
            _fireComponent.OnFire -= _fireVFX.Play;
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