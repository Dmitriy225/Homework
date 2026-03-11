using Modules;
using System;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinPool : MonoMemoryPool<Vector2Int, Coin>
    {
    }
}