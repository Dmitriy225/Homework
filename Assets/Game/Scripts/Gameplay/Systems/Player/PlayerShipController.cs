using UnityEngine;

namespace Game
{
    public sealed class PlayerShipController : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip _ship;

        private MovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent = _ship.GetComponent<MovementComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ship.Fire();
            }

            float dx = Input.GetAxisRaw("Horizontal");
            float dy = Input.GetAxisRaw("Vertical");
            _movementComponent.Direction = new Vector2(dx, dy);
        }
    }
}