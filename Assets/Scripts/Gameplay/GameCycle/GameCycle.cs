using System;
using UnityEngine;

namespace SnakeGame
{
    public sealed class GameCycle
    {
        public event Action<bool> OnFinished;

        private bool _isFinished = false;

        public void Finish(bool win)
        {
            if (!_isFinished)
            {
                OnFinished?.Invoke(win);
                _isFinished = true;
            }
        }
    }
}