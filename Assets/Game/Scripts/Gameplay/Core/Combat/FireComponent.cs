using System;
using UnityEngine;

namespace Game
{
    public sealed class FireComponent : MonoBehaviour
    {
        public event Action OnFire;

        [SerializeField]
        private float _fireCooldown = 0.25f;

        private Cooldown _cooldown;
        private Func<bool> _condition;

        public void Construct(Func<bool> condition)
        {
            _condition = condition;
            _cooldown = new Cooldown(_fireCooldown);
        }

        private void Update()
        {
            _cooldown.Tick(Time.deltaTime);
        }

        public void TryFire()
        {
            if (!_cooldown.IsCompleted() || !_condition.Invoke())
            {
                return;
            }

            OnFire?.Invoke();
            _cooldown.Reset();
        }
    }
}