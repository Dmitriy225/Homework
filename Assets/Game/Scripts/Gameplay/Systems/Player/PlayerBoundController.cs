using Modules.Utils;
using UnityEngine;

namespace Game
{
    public sealed class PlayerBoundController : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private TransformBounds _area;

        private void LateUpdate()
        {
            _transform.position = _area.ClampInBounds(_transform.position);
        }
    }
}