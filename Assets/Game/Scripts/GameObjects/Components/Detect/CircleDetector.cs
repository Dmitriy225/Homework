using System;
using UnityEngine;

namespace Game
{
    public sealed class CircleDetector : MonoBehaviour
    {
        [SerializeField]
        private Transform _point;

        [Min(0)]
        [SerializeField]
        private float _radius;

        [SerializeField]
        private LayerMask _layerMask;

        public Collider2D Detect()
        {
            return Physics2D.OverlapCircle(_point.position, _radius, _layerMask.value);
        }
    }
}