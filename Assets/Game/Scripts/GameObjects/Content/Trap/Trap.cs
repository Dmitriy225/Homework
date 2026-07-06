using UnityEngine;

namespace Game
{
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [Min(0)]
        [SerializeField]
        private int damage;

        [SerializeField]
        private CollisionComponent _collisionComponent;

        private void OnEnable()
        {
            _healthComponent.OnDied += OnDied;
            _collisionComponent.OnEntered += OnCollisionEntered;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= OnDied;
            _collisionComponent.OnEntered -= OnCollisionEntered;
        }

        private void OnDied()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEntered(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<HealthComponent>(out var health))
            {
                health.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}