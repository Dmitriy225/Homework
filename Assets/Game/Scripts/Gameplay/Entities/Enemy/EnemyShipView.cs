using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyShipView : MonoBehaviour
    {
        [SerializeField]
        private EnemyShip _ship;

        private FireComponent _fireComponent;

        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private Material _material;

        [SerializeField]
        private ParticleSystem _fireVFX;

        private void Awake()
        {
            _fireComponent = _ship.GetComponent<FireComponent>();
            _renderer.material = _material;
        }

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