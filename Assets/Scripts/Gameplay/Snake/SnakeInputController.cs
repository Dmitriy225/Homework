using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeInputController : ITickable
    {
        private readonly ISnake _snake;

        public SnakeInputController(ISnake snake)
        {
            _snake = snake;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _snake.Turn(SnakeDirection.LEFT);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _snake.Turn(SnakeDirection.UP);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _snake.Turn(SnakeDirection.DOWN);
            }
        }
    }
}