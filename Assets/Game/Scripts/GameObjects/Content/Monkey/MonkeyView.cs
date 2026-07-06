using System;
using UnityEngine;

namespace Game
{
    public sealed class MonkeyView : MonoBehaviour
    {
        private static readonly int deathId = Animator.StringToHash("Death");
        private static readonly int groundId = Animator.StringToHash("IsGrounded");
        private static readonly int jumpId = Animator.StringToHash("Jump");

        private HealthComponent _healthComponent;
        private GroundedComponent _groundedComponent;
        private JumpDelayRequestComponent _jumpComponent;

        [SerializeField]
        private Animator _animator;

        private TakeDamageColorComponent _takeDamageColorComponent;

        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
            _groundedComponent = GetComponentInParent<GroundedComponent>();
            _jumpComponent = GetComponentInParent<JumpDelayRequestComponent>();
            _takeDamageColorComponent = GetComponent<TakeDamageColorComponent>();
        }

        private void OnEnable()
        {
            _healthComponent.OnHealthChanged += OnHealthChanged;
            _healthComponent.OnDied += OnDied;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthChanged -= OnHealthChanged;
            _healthComponent.OnDied -= OnDied;
            _jumpComponent.OnJump -= OnJump;
        }

        private void Update()
        {
            _animator.SetBool(groundId, _groundedComponent.IsGrounded);
        }

        private void OnHealthChanged(float _)
        {
            _takeDamageColorComponent.TakeDamage();
        }

        private void OnDied()
        {
            _animator.SetTrigger(deathId);
        }

        private void OnJump()
        {
            _animator.SetTrigger(jumpId);
        }
    }
}