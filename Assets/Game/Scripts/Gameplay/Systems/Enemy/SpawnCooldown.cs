using UnityEngine;

namespace Game
{
    public sealed class SpawnCooldown : MonoBehaviour
    {
        [SerializeField]
        private float _minCooldown = 2;

        [SerializeField]
        private float _maxСooldown = 3;

        private Cooldown _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldown(NextSpawnDuration());
        }

        private void FixedUpdate()
        {
            _cooldown.Tick(Time.fixedDeltaTime);
        }

        public bool IsCompleted()
        {
            return _cooldown.IsCompleted();
        }

        public void Restart()
        {
            _cooldown.SetDuration(NextSpawnDuration());
            _cooldown.Reset();
        }

        private float NextSpawnDuration()
        {
            return Random.Range(_minCooldown, _maxСooldown);
        }
    }
}