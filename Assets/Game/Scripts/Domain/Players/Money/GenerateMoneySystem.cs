using System;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct GenerateMoneySystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (
                var (money, moneyCooldown)
                in SystemAPI.Query<RefRW<Money>, RefRW<MoneyCooldown>>()
                .WithPresent<Player>()
            )
            {
                if (moneyCooldown.ValueRO.Time > 0)
                {
                    continue;
                }

                money.ValueRW.Value++;
                moneyCooldown.ValueRW.Time = moneyCooldown.ValueRO.Duration;
            }
        }
    }
}