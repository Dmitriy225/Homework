using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    [BurstCompile]
    public partial struct MoveSystem : ISystem
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
                    moveSpeed,
                    rotationSpeed,
                    health,
                    eventEnabled)
                in SystemAPI.Query<
                    EnabledRefRW<MoveRequest>,
                    RefRO<MoveRequest>,
                    RefRW<LocalTransform>,
                    RefRO<MoveSpeed>,
                    RefRO<RotationSpeed>,
                    RefRO<Health>,
                    EnabledRefRW<MoveEvent>>()
                    .WithPresent<Movable>()
                    .WithPresent<MoveEvent>()
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
                
                if (!MoveUseCase.MoveStep(
                    ref transform.ValueRW,
                    direction,
                    moveSpeed.ValueRO,
                    deltaTime))
                {
                    continue;
                }

                RotationUseCase.RotateStep(
                    ref transform.ValueRW,
                    direction,
                    rotationSpeed.ValueRO,
                    deltaTime
                );

                // Event
                eventEnabled.ValueRW = true;
            }
        }
    }
}