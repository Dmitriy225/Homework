using Modules;
using System;

namespace SnakeGame
{
    public sealed class SnakeCoinConsumer
    {
        public event Action<ICoin> OnConsumed;

        private readonly ISnake _snake;

        public SnakeCoinConsumer(ISnake snake)
        {
            _snake = snake;
        }

        public void Consume(ICoin coin)
        {
            _snake.Expand(coin.Bones);
            OnConsumed?.Invoke(coin);
        }
    }
}