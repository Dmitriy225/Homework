using DG.Tweening;
using Modules.Utils;
using UnityEngine;

namespace Game
{
    public sealed class PlayerShipView : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip _ship;

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
            _renderer.material = _material;
        }

        private void OnEnable()
        {
            _ship.OnMoved += OnShipMoved;
            _ship.OnHealthReduced += OnHealthReduced;
            _ship.OnHealthReduced += _damageViewComponent.AnimateDamage;
            _ship.OnHealthReduced += _cameraShaker.Shake;
            _ship.OnDied += _deadViewComponent.InstantiateEffect;
            _ship.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _ship.OnMoved -= OnShipMoved;
            _ship.OnHealthReduced -= OnHealthReduced;
            _ship.OnHealthReduced -= _damageViewComponent.AnimateDamage;
            _ship.OnHealthReduced -= _cameraShaker.Shake;
            _ship.OnDied -= _deadViewComponent.InstantiateEffect;
            _ship.OnFire -= OnFire;
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