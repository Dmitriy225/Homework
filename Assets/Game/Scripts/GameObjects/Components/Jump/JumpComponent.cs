using System;
using UnityEngine;

namespace Game
{
    public sealed class JumpComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Vector2 _force;

        public void Jump()
        {
            _rigidbody.AddForce(_force, ForceMode2D.Impulse);
        }
    }
}