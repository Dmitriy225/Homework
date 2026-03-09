using UnityEngine;

namespace Game
{
    public sealed class MovementViewComponent : MonoBehaviour
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private Transform _viewTransform;

        [SerializeField]
        private MovementViewConfig _movementViewConfig;

        private Vector2 _direction;

        private void OnEnable()
        {
            _movementComponent.OnMoved += OnMoved;
        }

        private void OnDisable()
        {
            _movementComponent.OnMoved -= OnMoved;
        }

        private void LateUpdate()
        {
            AnimateMovement(Time.deltaTime);
        }

        private void OnMoved(Vector2 direction)
        {
            _direction = direction;
        }

        private void AnimateMovement(float deltaTime)
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