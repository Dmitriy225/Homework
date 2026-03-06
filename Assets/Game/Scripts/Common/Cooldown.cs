using System;

namespace Game
{
    public sealed class Cooldown
    {
        public event Action OnCompleted;

        public float Time
        {
            get => _time;
        }

        public float Duration
        {
            get => _duration;
        }

        private float _time;
        private float _duration;

        public Cooldown(float duration)
        {
            _time = duration;
            _duration = duration;
        }

        public void SetDuration(float duration)
        {
            _duration = duration;
        }

        public bool IsCompleted()
        {
            return _time <= 0;
        }

        public void Tick(float deltaTime)
        {
            if (_time == 0)
            {
                return;
            }

            _time = Math.Max(0, _time - deltaTime);

            if (_time <= 0)
            {
                OnCompleted?.Invoke();
            }
        }

        public void Reset()
        {
            _time = _duration;
        }
    }
}