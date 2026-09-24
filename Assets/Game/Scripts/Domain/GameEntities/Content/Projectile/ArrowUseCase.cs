using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    public static class ArrowUseCase
    {
        public static void SpawnProjectile(
            ref EntityCommandBuffer ecb,
            ArrowPrefab projectilePrefab,
            LocalTransform transform,
            AttackOffset attackOffset,
            Team team,
            Entity target
        )
        {
            Entity projectile = ecb.Instantiate(projectilePrefab.Value);

            float3 spawnPosition = AttackUseCase.GetFirePoint(transform, attackOffset);
            quaternion spawnRotation = transform.Rotation;
            
            ecb.SetComponent(projectile, LocalTransform.FromPositionRotation(spawnPosition, spawnRotation));
            ecb.SetComponent(projectile, team);
            ecb.SetComponent(projectile, new TargetEntity
            {
                Value = target
            });
        }
    }
}