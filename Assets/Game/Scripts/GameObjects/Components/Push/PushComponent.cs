using System;
using UnityEngine;

namespace Game
{
    public sealed class PushComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _origin;

        [SerializeField]
        private Vector2 _force;

        public void Push(Rigidbody2D rigidbody)
        {
            float directionX = Mathf.Sign(rigidbody.transform.position.x - _origin.position.x);
            Vector2 pushForce = new Vector2(directionX * _force.x, _force.y);
            rigidbody.AddForce(pushForce, ForceMode2D.Impulse);
        }
    }
}