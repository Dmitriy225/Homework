using System;
using UnityEngine;

namespace Game
{
    public sealed class CharacterView : MonoBehaviour
    {
        private static readonly int movementId = Animator.StringToHash("IsMoving");
        private static readonly int deathId = Animator.StringToHash("Death");
        private static readonly int groundId = Animator.StringToHash("IsGrounded");
        private static readonly int jumpId = Animator.StringToHash("Jump");   
        private static readonly int blowUpId = Animator.StringToHash("BlowUp");   
        private static readonly int blowForwardId = Animator.StringToHash("BlowForward");   

        private HealthComponent _healthComponent;
        private MoveRequestComponent _moveComponent;
        private JumpDelayRequestComponent _jumpComponent;
        private GroundedComponent _groundedComponent;

        [SerializeField]
        private PushDelayRequestComponent _tossComponent;

        [SerializeField]
        private PushDelayRequestComponent _pushComponent;

        [SerializeField]
        private Animator _animator;

        private TakeDamageColorComponent _takeDamageColorComponent;

        [SerializeField]
        private ParticleSystem _tossParticle;

        [SerializeField]
        private ParticleSystem _pushParticle;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _jumpClip;

        [SerializeField]
        private AudioClip _takeDamageClip;

        [SerializeField]
        private AudioClip _tossClip;

        [SerializeField]
        private AudioClip _pushClip;

        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
            _moveComponent = GetComponentInParent<MoveRequestComponent>();
            _jumpComponent = GetComponentInParent<JumpDelayRequestComponent>();
            _groundedComponent = GetComponentInParent<GroundedComponent>();
            _takeDamageColorComponent = GetComponent<TakeDamageColorComponent>();
        }

        private void OnEnable()
        {
            _healthComponent.OnHealthChanged += OnHealthChanged;
            _healthComponent.OnDied += OnDied;
            _jumpComponent.OnJump += OnJump;
            _tossComponent.OnPush += OnToss;
            _pushComponent.OnPush += OnPush;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthChanged -= OnHealthChanged;
            _healthComponent.OnDied -= OnDied;
            _jumpComponent.OnJump -= OnJump;
            _tossComponent.OnPush -= OnToss;
            _pushComponent.OnPush -= OnPush;
        }

        private void Update()
        {
            _animator.SetBool(movementId, _moveComponent.IsMoving);
            _animator.SetBool(groundId, _groundedComponent.IsGrounded);
        }

        private void OnHealthChanged(float _)
        {
            _takeDamageColorComponent.TakeDamage();
            _audioSource.PlayOneShot(_takeDamageClip);
        }

        private void OnDied()
        {
            _animator.SetTrigger(deathId);
        }

        private void OnJump()
        {
            _animator.SetTrigger(jumpId);
            _audioSource.PlayOneShot(_jumpClip);
        }

        private void OnToss()
        {
            _animator.SetTrigger(blowForwardId);
            _tossParticle.Play();
            _audioSource.PlayOneShot(_tossClip);
        }

        private void OnPush()
        {
            _animator.SetTrigger(blowUpId);
            _pushParticle.Play();
            _audioSource.PlayOneShot(_pushClip);
        }
    }
}