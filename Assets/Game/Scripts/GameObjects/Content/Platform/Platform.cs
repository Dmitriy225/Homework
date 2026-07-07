using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Platform : MonoBehaviour, MoveRequestComponent.IAction
    {
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveComponent;
        private PatrolComponent _patrolComponent;

        private void Awake()
        {
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveComponent = GetComponent<MoveTransformComponent>();
            _patrolComponent = GetComponent<PatrolComponent>();
        }

        private void Start()
        {
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(() => true);
            _patrolComponent.SetCondition(() => true);
        }

        private void FixedUpdate()
        {
            _moveRequestComponent.SetDirection(_patrolComponent.Direction);
        }

        public void Invoke(Vector2 direction)
        {
            _moveComponent.Move(direction);
        }
    }
}