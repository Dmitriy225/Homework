using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class SnakeInputController : ITickable
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        private readonly ISnake _snake;

        public SnakeInputController(ISnake snake)
        {
            _snake = snake;
        }

        public void Tick()
        {
            if (Input.GetAxisRaw(HORIZONTAL) == -1)
            {
                _snake.Turn(SnakeDirection.LEFT);
            }
            else if (Input.GetAxisRaw(HORIZONTAL) == 1)
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
            else if (Input.GetAxisRaw(VERTICAL) == 1)
            {
                _snake.Turn(SnakeDirection.UP);
            }
            else if (Input.GetAxisRaw(VERTICAL) == -1)
            {
                _snake.Turn(SnakeDirection.DOWN);
            }
        }
    }
}