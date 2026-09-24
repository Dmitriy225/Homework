using System;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct AttackCooldownSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var cooldown in SystemAPI.Query<RefRW<AttackCooldown>>())
            {
                cooldown.ValueRW.Tick(deltaTime);
            }
        }
    }
}