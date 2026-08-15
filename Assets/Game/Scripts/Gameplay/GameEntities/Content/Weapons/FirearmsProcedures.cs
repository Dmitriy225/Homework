using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public static class FirearmsProcedures
    {
        public static void PerformBulletFire(this IGameEntity entity, IGameContext gameContext)
        {
            var firePosition = entity.GetFirePosition().Value;
            var rotation = entity.GetRotation().Value;
            var bulletPrefab = entity.GetBulletPrefab().Value;
            var fireSpread = entity.GetFireSpread().Value;

            float spreadOffset = Random.Range(-fireSpread, fireSpread);
            var finalRotation = rotation * Quaternion.AngleAxis(spreadOffset, Vector3.up);
            BulletProcedures.Rent(gameContext, bulletPrefab, firePosition, finalRotation);
        }
    }
}