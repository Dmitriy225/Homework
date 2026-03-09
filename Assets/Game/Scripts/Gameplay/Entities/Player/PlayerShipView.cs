using Modules.Utils;
using UnityEngine;

namespace Game
{
    public sealed class PlayerShipView : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _damageSFX;

        [SerializeField]
        private CameraShaker _cameraShaker;

        private void OnEnable()
        {
            _healthComponent.OnReduced += OnHealthReduced;
        }

        private void OnDisable()
        {
            _healthComponent.OnReduced -= OnHealthReduced;
        }

        private void OnHealthReduced()
        {
            _cameraShaker.Shake();
            _audioSource.PlayOneShot(_damageSFX);
        }
    }
}