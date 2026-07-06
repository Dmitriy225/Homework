using System;
using UnityEngine;

namespace Game
{
    public sealed class FollowTargetComponent : MonoBehaviour
    {
        [SerializeField]
        private MoveRequestComponent _moveRequestComponent;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                _moveRequestComponent.SetDirection(new Vector2(_target.position.x - transform.position.x, 0f));
            }
            else
            {
                _moveRequestComponent.SetDirection(Vector2.zero);
            }
        }
    }
}