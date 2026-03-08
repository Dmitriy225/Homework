using UnityEngine;

namespace Game
{
    public sealed class MovementViewComponent : MonoBehaviour
    {
        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        [SerializeField]
        private Transform _viewTransform;

        [SerializeField]
        private MovementViewConfig _movementViewConfig;

        private Vector2 _direction;

        public void AnimateMovement(float deltaTime)
        {
            float moveRotationAngle = _movementViewConfig.MoveRotationAngle;
            float moveSpeed = _movementViewConfig.MoveSpeed;

            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = moveRotationAngle * _direction.y;
            shipAngles.y = moveRotationAngle / 2 * _direction.x * -1f;

            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = moveSpeed * deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }
    }
}