using UnityEngine;

namespace Game
{
    public sealed class PlayerShipController : MonoBehaviour
    {
        [SerializeField]
        private PlayerShip _ship;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ship.Fire();
            }

            float dx = Input.GetAxisRaw("Horizontal");
            float dy = Input.GetAxisRaw("Vertical");
            _ship.MoveDirection = new Vector2(dx, dy);
        }
    }
}