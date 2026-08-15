using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class Health
    {
        public event Action OnStateChanged;
        public event Action<int> OnCurrentChanged;
        public event Action<int> OnMaxChanged;
        public event Action<int> OnReduced;
        public event Action OnEmptied;

        public int Current
        {
            get => _current;
        }

        public int Max
        {
            get => _max;
        }

#if NEWTONSOFT_JSON
        [JsonIgnore]
#endif
        public bool IsEmpty
        {
            get => _current <= 0;
        }

#if NEWTONSOFT_JSON
        [JsonIgnore]
#endif
        public bool IsNotEmpty
        {
            get => _current > 0;
        }

#if NEWTONSOFT_JSON
        [JsonIgnore]
#endif
        public bool IsFull
        {
            get => _current >= _max;
        }

#if NEWTONSOFT_JSON
        [JsonIgnore]
#endif
        public float Percent
        {
            get => (float)_current / _max;
        }

        [SerializeField, Min(0)]
        private int _current;

        [SerializeField, Min(1)]
        private int _max;

        public Health(int max) : this(max, max)
        {
        }

        public Health(int current, int max)
        {
            this._max = Mathf.Max(1, max);
            this._current = Math.Clamp(current, 0, this._max);
        }

        public void SetCurrent(int current)
        {
            if (current < 0)
            {
                throw new ArgumentException();
            }

            if (this._current == current)
            {
                return;
            }

            this._current = Math.Clamp(current, 0, _max);
            OnCurrentChanged?.Invoke(this._current);
            OnStateChanged?.Invoke();

            if (this._current == 0)
            {
                OnEmptied?.Invoke();
            }
        }

        public void SetMax(int max)
        {
            if (max < 0)
            {
                throw new ArgumentException();
            }

            if (this._max == max)
            {
                return;
            }

            this._max = max;
            OnMaxChanged?.Invoke(this._max);
            int current = Math.Min(this._current, this._max);

            if (current != this._current)
            {
                this._current = current;
                OnCurrentChanged?.Invoke(current);
            }

            OnStateChanged?.Invoke();
        }

        public bool Add(int range)
        {
            if (range < 0)
            {
                throw new ArgumentException();
            }

            if (range == 0 || _current == _max)
            {
                return false;
            }

            _current = Math.Min(_current + range, _max);
            OnCurrentChanged?.Invoke(_current);
            OnStateChanged?.Invoke();
            return true;
        }

        public bool Reduce(int range)
        {
            if (range < 0)
            {
                throw new ArgumentException();
            }

            if (_current == 0 || range == 0)
            {
                return false;
            }

            _current = Math.Max(0, _current - range);
            OnReduced?.Invoke(_current);
            OnCurrentChanged?.Invoke(_current);
            OnStateChanged?.Invoke();

            if (_current == 0)
            {
                OnEmptied?.Invoke();
            }

            return true;
        }       

        public void AssignMax()
        {
            SetCurrent(_max);
        }       
    }
}