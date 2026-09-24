using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct RotationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (
                var (
                    requestEnabled,
                    request,
                    transform,
                    rotationSpeed,
                    health)
                in SystemAPI.Query<
                    EnabledRefRW<RotationRequest>,
                    RefRO<RotationRequest>,
                    RefRW<LocalTransform>,
                    RefRO<RotationSpeed>,
                    RefRO<Health>>()
                    .WithPresent<Movable>()
            )
            {
                // Request
                requestEnabled.ValueRW = false;

                // Condition
                if (health.ValueRO.IsDead())
                {
                    continue;
                }

                // Action
                float3 direction = request.ValueRO.Direction;
                RotationUseCase.RotateStep(
                    ref transform.ValueRW,
                    direction,
                    rotationSpeed.ValueRO,
                    deltaTime
                );
            }
        }
    }
}