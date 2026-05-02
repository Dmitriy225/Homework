using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinPool : MonoMemoryPool<Vector2Int, Coin>
    {
        protected override void Reinitialize(Vector2Int position, Coin coin)
        {
            coin.Position = position;
        }

        protected override void OnSpawned(Coin coin)
        {
            base.OnSpawned(coin);
            coin.Generate();
        }
    }
}