using UnityEngine;

namespace Game
{
    public sealed class PlayerShipController : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip _ship;

        private MovementComponent _movementComponent;
        private FireComponent _fireComponent;

        private void Awake()
        {
            _movementComponent = _ship.GetComponent<MovementComponent>();
            _fireComponent = _ship.GetComponent<FireComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _fireComponent.TryFire();
            }

            float dx = Input.GetAxisRaw("Horizontal");
            float dy = Input.GetAxisRaw("Vertical");
            _movementComponent.Direction = new Vector2(dx, dy);
        }
    }
}