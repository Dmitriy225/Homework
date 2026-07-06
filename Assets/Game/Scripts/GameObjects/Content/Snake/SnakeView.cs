using System;
using UnityEngine;

namespace Game
{
    public sealed class SnakeView : MonoBehaviour
    {
        private static readonly int movementId = Animator.StringToHash("IsMoving");
        private static readonly int deathId = Animator.StringToHash("Death");
        private static readonly int groundId = Animator.StringToHash("IsGrounded");

        private HealthComponent _healthComponent;
        private MoveRequestComponent _moveComponent;
        private GroundedComponent _groundedComponent;
        private TakeDamageColorComponent _takeDamageColorComponent;

        [SerializeField]
        private Animator _animator;

        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
            _moveComponent = GetComponentInParent<MoveRequestComponent>();
            _groundedComponent = GetComponentInParent<GroundedComponent>();
            _takeDamageColorComponent = GetComponent<TakeDamageColorComponent>();
        }

        private void OnEnable()
        {
            _healthComponent.OnHealthChanged += OnHealthChanged;
            _healthComponent.OnDied += OnDied;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthChanged -= OnHealthChanged;
            _healthComponent.OnDied -= OnDied;
        }

        private void Update()
        {
            _animator.SetBool(movementId, _moveComponent.IsMoving);
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
    }
}