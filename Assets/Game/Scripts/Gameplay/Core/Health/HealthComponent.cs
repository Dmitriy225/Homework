using System;
using UnityEngine;

namespace Game
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action<int, int> OnStateChanged;
        public event Action OnReduced;
        public event Action OnEmptied;

        public int Current
        {
            get => _current;
        }

        public int Max
        {
            get => _max;
        }

        private int _current;
        private int _max;

        public void Construct(int current)
        {
            _current = current;
            _max = current;
        }

        public bool Exists()
        {
            return _current > 0;
        }

        public bool IsEmpty()
        {
            return _current <= 0;
        }

        public bool Reduce(int value)
        {
            if (value <= 0)
            {
                return false;
            }

            _current = Mathf.Clamp(_current - value, 0, _max);
            OnStateChanged?.Invoke(_current, _max);
            OnReduced?.Invoke();

            if (_current == 0)
            {
                OnEmptied?.Invoke();
            }

            return true;
        }
    }
}