using DG.Tweening;
using Modules.Utils;
using UnityEngine;

namespace Game
{
    public sealed class PlayerShipView : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip _ship;

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
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _fireSFX;

        [SerializeField]
        private AudioClip _damageSFX;

        [SerializeField]
        private ParticleSystem _fireVFX;

        [SerializeField]
        private CameraShaker _cameraShaker;

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
            _healthComponent.OnReduced += OnHealthReduced;
            _healthComponent.OnReduced += _damageViewComponent.AnimateDamage;
            _healthComponent.OnReduced += _cameraShaker.Shake;
            _healthComponent.OnEmptied += _deadViewComponent.InstantiateEffect;
            _fireComponent.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _movementComponent.OnMoved -= OnShipMoved;
            _healthComponent.OnReduced -= OnHealthReduced;
            _healthComponent.OnReduced -= _damageViewComponent.AnimateDamage;
            _healthComponent.OnReduced -= _cameraShaker.Shake;
            _healthComponent.OnEmptied -= _deadViewComponent.InstantiateEffect;
            _fireComponent.OnFire -= OnFire;
        }

        private void LateUpdate()
        {
            _movementViewComponent.AnimateMovement(Time.deltaTime);
        }

        private void OnShipMoved(Vector2 direction)
        {
            _movementViewComponent.Direction = direction;
        }

        private void OnFire()
        {
            _audioSource.PlayOneShot(_fireSFX);
            _fireVFX.Play();
        }

        private void OnHealthReduced()
        {
            _audioSource.PlayOneShot(_damageSFX);
        }
    }
}