using UnityEngine;

namespace Game
{
    public static class HealthProcedures
    {
        public static bool TakeDamage(this Collider collider, IGameEntity instigator)
        {
            return collider.TryGetComponent<IGameEntity>(out var entity)
                && TakeDamage(entity, instigator);
        }

        public static bool TakeDamage(this IGameEntity entity, IGameEntity instigator)
        {
            return instigator.TryGetDamage(out var damage)
                && TakeDamage(entity, damage.Value);
        }

        public static bool TakeDamage(this Collider collider, int damage)
        {
            return collider.TryGetComponent<IGameEntity>(out var entity)
                && entity.TakeDamage(damage);
        }

        public static bool TakeDamage(this IGameEntity entity, int damage)
        {
            return entity.TryGetHealth(out var health)
                && health.Reduce(damage);
        }

        public static bool Heal(this IGameEntity entity, int hitPoints)
        {
            return entity.TryGetHealth(out var health)
                && health.Add(hitPoints);
        }
    }
}