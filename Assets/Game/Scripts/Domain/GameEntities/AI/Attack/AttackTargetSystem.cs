using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct AttackTargetSystem : ISystem
    {
        private ComponentLookup<LocalTransform> _transformLookup;
        private ComponentLookup<Health> _healthLookup;
        private ComponentLookup<TargetEntity> _targetLookup;

        public void OnCreate(ref SystemState state)
        {
            _transformLookup = SystemAPI.GetComponentLookup<LocalTransform>(true);
            _healthLookup = SystemAPI.GetComponentLookup<Health>(true);
            _targetLookup = SystemAPI.GetComponentLookup<TargetEntity>(true);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _transformLookup.Update(ref state);
            _healthLookup.Update(ref state);
            _targetLookup.Update(ref state);

            foreach (
                var (
                    attackDistance,
                    moveRequest,
                    moveRequestEnabled,
                    rotationRequest,
                    rotationRequestEnabled,
                    attackRequest,
                    attackRequestEnabled,
                    entity)
                in SystemAPI.Query<
                    RefRO<AttackDistance>,
                    RefRW<MoveRequest>,
                    EnabledRefRW<MoveRequest>,
                    RefRW<RotationRequest>,
                    EnabledRefRW<RotationRequest>,
                    RefRW<AttackRequest>,
                    EnabledRefRW<AttackRequest>>()
                    .WithPresent<MoveRequest>()
                    .WithPresent<RotationRequest>()
                    .WithPresent<AttackRequest>()
                    .WithPresent<Unit>()
                    .WithEntityAccess()
            )
            {
                if (!_targetLookup.TryGetComponent(entity, out var target))
                {
                    continue;
                }

                Entity targetValue = target.Value;

                if (targetValue == Entity.Null
                    || !_transformLookup.TryGetComponent(targetValue, out LocalTransform targetTransform)
                    || !_healthLookup.TryGetComponent(targetValue, out Health targetHealth)
                    || targetHealth.IsDead())
                {
                    continue;
                }

                float3 currentPosition = _transformLookup.GetRefRO(entity).ValueRO.Position;
                float3 delta = targetTransform.Position - currentPosition;
                float attackRange = attackDistance.ValueRO.Value;
                float3 direction = math.normalizesafe(delta);

                if (math.lengthsq(delta) > attackRange * attackRange)
                {
                    moveRequest.ValueRW.Direction = direction;
                    moveRequestEnabled.ValueRW = true;
                }
                else
                {
                    rotationRequest.ValueRW.Direction = direction;
                    rotationRequestEnabled.ValueRW = true;
                    attackRequest.ValueRW.Target = targetValue;
                    attackRequestEnabled.ValueRW = true;
                }
            }
        }
    }
}