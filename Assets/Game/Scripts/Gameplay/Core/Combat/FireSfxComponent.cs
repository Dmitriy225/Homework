using System;
using UnityEngine;

namespace Game
{
    public sealed class FireSfxComponent : MonoBehaviour
    {
        [SerializeField]
        private FireComponent _fireComponent;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _fireSFX;

        private void OnEnable()
        {
            _fireComponent.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _fireComponent.OnFire -= OnFire;
        }

        private void OnFire()
        {
            _audioSource.PlayOneShot(_fireSFX);
        }
    }
}