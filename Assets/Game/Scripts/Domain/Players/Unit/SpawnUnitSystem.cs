using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct SpawnUnitSystem : ISystem
    {
        private Unity.Mathematics.Random _random;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
            _random = new Unity.Mathematics.Random(123);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged);

            foreach (
                var (
                configBuffer,
                spawnPositionBuffer,
                requestEnabled,
                request,
                team,
                money
                ) in SystemAPI.Query<
                    DynamicBuffer<UnitConfigBuffer>,
                    DynamicBuffer<SpawnPositionBuffer>,
                    EnabledRefRW<SpawnUnitRequest>,
                    RefRO<SpawnUnitRequest>,
                    RefRO<Team>,
                    RefRW<Money>
                >()
            )
            {
                requestEnabled.ValueRW = false;

                if (!UnitUseCase.CanBuyUnit(money.ValueRO, configBuffer, request.ValueRO.UnitName))
                {
                    continue;
                }

                var index = _random.NextInt(0, spawnPositionBuffer.Length);
                UnitUseCase.BuyUnit(
                    ref ecb,
                    ref money.ValueRW,
                    configBuffer,
                    request.ValueRO.UnitName,
                    spawnPositionBuffer[index].Position,
                    team.ValueRO
                );
            }
        }
    }
}