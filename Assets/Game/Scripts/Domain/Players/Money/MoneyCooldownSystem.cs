using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct MoneyCooldownSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var cooldown in SystemAPI.Query<RefRW<MoneyCooldown>>())
            {

                cooldown.ValueRW.Time = math.max(0, cooldown.ValueRO.Time - deltaTime);
            }
        }
    }
}