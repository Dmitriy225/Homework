using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeInputController : ITickable
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private readonly ISnake _snake;

        public SnakeInputController(ISnake snake)
        {
            _snake = snake;
        }

        public void Tick()
        {
            if (Input.GetAxisRaw(Horizontal) == -1)
            {
                _snake.Turn(SnakeDirection.LEFT);
            }
            else if (Input.GetAxisRaw(Horizontal) == 1)
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
            else if (Input.GetAxisRaw(Vertical) == 1)
            {
                _snake.Turn(SnakeDirection.UP);
            }
            else if (Input.GetAxisRaw(Vertical) == -1)
            {
                _snake.Turn(SnakeDirection.DOWN);
            }
        }
    }
}