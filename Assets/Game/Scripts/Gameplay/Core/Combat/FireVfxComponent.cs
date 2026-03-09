using System;
using UnityEngine;

namespace Game
{
    public sealed class FireVfxComponent : MonoBehaviour
    {
        [SerializeField]
        private FireComponent _fireComponent;

        [SerializeField]
        private ParticleSystem _fireVFX;

        private void OnEnable()
        {
            _fireComponent.OnFire += _fireVFX.Play;
        }

        private void OnDisable()
        {
            _fireComponent.OnFire -= _fireVFX.Play;
        }
    }
}