using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace SampleGame
{
    [BurstCompile]
    public partial struct BuyEnemyUnitSystem : ISystem
    {
        private Random _random;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
            _random = new Random(123);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged);

            foreach (
                var (
                    configBuffer,
                    selectedUnit,
                    money,
                    spawnBuffer,
                    team
                ) in SystemAPI.Query<
                    DynamicBuffer<UnitConfigBuffer>,
                    RefRW<SelectedUnit>,
                    RefRW<Money>,
                    DynamicBuffer<SpawnPositionBuffer>,
                    RefRO<Team>
                >()
            )
            {
                if (selectedUnit.ValueRO.Name.IsEmpty)
                {
                    if (configBuffer.Length == 0)
                        continue;

                    int index = _random.NextInt(0, configBuffer.Length);
                    var config = configBuffer[index];
                    selectedUnit.ValueRW.Name = config.Name;
                }

                if (!UnitUseCase.CanBuyUnit(money.ValueRW, configBuffer, selectedUnit.ValueRO.Name))
                {
                    continue;
                }

                UnitUseCase.BuyUnit(
                    ref ecb,
                    ref money.ValueRW,
                    configBuffer,
                    selectedUnit.ValueRO.Name,
                    spawnBuffer[_random.NextInt(0, spawnBuffer.Length)].Position,
                    team.ValueRO
                );

                selectedUnit.ValueRW.Name = default;
            }
        }
    }
}