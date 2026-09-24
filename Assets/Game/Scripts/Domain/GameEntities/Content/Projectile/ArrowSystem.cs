using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct ArrowSystem : ISystem
    {
        private ComponentLookup<LocalTransform> _transformLookup;
        private BufferLookup<TakeDamageRequest> _takeDamageRequestLookup;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
            _transformLookup = SystemAPI.GetComponentLookup<LocalTransform>(isReadOnly: true);
            _takeDamageRequestLookup = SystemAPI.GetBufferLookup<TakeDamageRequest>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Dependency.Complete();
            _transformLookup.Update(ref state);
            _takeDamageRequestLookup.Update(ref state);
            float deltaTime = SystemAPI.Time.DeltaTime;

            EntityCommandBuffer ecb = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged);

            foreach ((
                        RefRW<LocalTransform> transform,
                        RefRO<MoveSpeed> moveSpeed,
                        RefRO<TargetEntity> targetRef,
                        RefRO<StoppingDistance> stoppingDistanceRef,
                        RefRO<Damage> damage,
                        RefRO<TargetOffset> offset,
                        Entity entity)
                     in SystemAPI.Query<
                        RefRW<LocalTransform>,
                        RefRO<MoveSpeed>,
                        RefRO<TargetEntity>,
                        RefRO<StoppingDistance>,
                        RefRO<Damage>,
                        RefRO<TargetOffset>>()
                        .WithPresent<Arrow>()
                        .WithEntityAccess())
            {
                Entity target = targetRef.ValueRO.Value;
                float3 direction = new();

                if (target == Entity.Null
                    || !_transformLookup.TryGetComponent(target, out LocalTransform targetTransform))
                {
                    direction = transform.ValueRO.Forward();
                    MoveUseCase.MoveStep(
                        ref transform.ValueRW,
                        direction,
                        in moveSpeed.ValueRO,
                        deltaTime
                    );

                    quaternion lookRotation = quaternion.LookRotationSafe(direction, math.up());
                    quaternion modelFix = quaternion.EulerXYZ(math.radians(-90f), 0f, 0f);
                    transform.ValueRW.Rotation = math.mul(lookRotation, modelFix);

                    continue;
                }

                float3 targetPosition = targetTransform.Position + math.rotate(targetTransform.Rotation, offset.ValueRO.Value);
                float3 delta = targetPosition - transform.ValueRO.Position;
                float stoppingDistance = stoppingDistanceRef.ValueRO.Value;

                if (math.lengthsq(delta) > stoppingDistance * stoppingDistance)
                {
                    direction = math.normalize(delta);
                    MoveUseCase.MoveStep(ref transform.ValueRW, direction, in moveSpeed.ValueRO, deltaTime);
                    transform.ValueRW.Rotation = quaternion.LookRotationSafe(direction, math.up());

                    quaternion lookRotation = quaternion.LookRotationSafe(direction, math.up());
                    quaternion modelFix = quaternion.EulerXYZ(math.radians(-90f), 0f, 0f);
                    transform.ValueRW.Rotation = math.mul(lookRotation, modelFix);
                    continue;
                }


                if (_takeDamageRequestLookup.TryGetBuffer(target, out DynamicBuffer<TakeDamageRequest> damageRequests))
                {
                    damageRequests.Add(new TakeDamageRequest
                    {
                        Damage = damage.ValueRO.Value,
                        Instigator = entity
                    });
                }

                ecb.DestroyEntity(entity);
            }
        }
    }
}