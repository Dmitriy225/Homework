using System;
using UnityEngine;

namespace Game
{
    public static class CombatProcedures
    {
        private static readonly Collider[] colliderBuffer = new Collider[16];

        public static bool CollectAmmo(this IGameEntity character, int amount)
        {
            if (amount > 0
                && character.TryGetWeapon(out var weapon)
                && weapon.Value != null
                && weapon.Value.TryGetAmmo(out var ammo))
            {
                ammo.Value += amount;
                return true;
            }

            return false;
        }

        public static void PerformSphereAttack(Vector3 position, float radius, LayerMask layerMask, int damage)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(
                position,
                radius,
                colliderBuffer,
                layerMask,
                QueryTriggerInteraction.Ignore
            );

            if (hitCount == 0)
            {
                return;
            }

            for (int i = 0; i < hitCount; i++)
            {
                colliderBuffer[i].TakeDamage(damage);
            }
        }     
    }
}