using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public sealed class Character : MonoBehaviour, MoveRequestComponent.IAction
    {
        private HealthComponent _healthComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;
        private LookComponent _lookComponent;
        private JumpDelayRequestComponent _jumpDelayRequestComponent;
        private GroundedComponent _groundedComponent;

        [SerializeField]
        private PushDelayRequestComponent _tossComponent;

        [SerializeField]
        private PushDelayRequestComponent _pushComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveTransformComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _jumpDelayRequestComponent = GetComponent<JumpDelayRequestComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
        }

        private void Start()
        {
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(() => _healthComponent.IsAlive);
            _jumpDelayRequestComponent.SetCondition(() => _groundedComponent.IsGrounded && _healthComponent.IsAlive);
            _tossComponent.SetCondition(() => _healthComponent.IsAlive && !_pushComponent.IsActive);
            _pushComponent.SetCondition(
                () =>
                    _healthComponent.IsAlive
                    && !_tossComponent.IsActive
                    && _groundedComponent.IsGrounded
            );
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += OnDied;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= OnDied;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A)) // TODO: Вынести управление в контроллер
            {
                _moveRequestComponent.SetDirection(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _moveRequestComponent.SetDirection(Vector2.right);
            }
            else
            {
                _moveRequestComponent.SetDirection(Vector2.zero);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpDelayRequestComponent.RequireJump();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                _tossComponent.RequirePush();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _pushComponent.RequirePush();
            }
        }

        public void Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
            _lookComponent.Look(direction.x);
        }

        private void OnDied()
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}