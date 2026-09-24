using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct SwordmanAttackSystem : ISystem
    {
        private ComponentLookup<LocalTransform> _transformLookup;
        private ComponentLookup<Team> _teamLookup;
        private ComponentLookup<Health> _healthLookup;
        private BufferLookup<TakeDamageRequest> _takeDamageRequestLookup;

        public void OnCreate(ref SystemState state)
        {
            _transformLookup = SystemAPI.GetComponentLookup<LocalTransform>(isReadOnly: true);
            _teamLookup = SystemAPI.GetComponentLookup<Team>(isReadOnly: true);
            _healthLookup = SystemAPI.GetComponentLookup<Health>(isReadOnly: true);
            _takeDamageRequestLookup = SystemAPI.GetBufferLookup<TakeDamageRequest>(isReadOnly: false);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            _transformLookup.Update(ref state);
            _teamLookup.Update(ref state);
            _healthLookup.Update(ref state);
            _takeDamageRequestLookup.Update(ref state);

            foreach (
                var (
                    requestEnabled,
                    request,
                    eventEnabled,
                    attackCooldown,
                    attackDelay,
                    attackDistance,
                    damage,
                    entity)
                in SystemAPI.Query<
                    EnabledRefRW<AttackRequest>,
                    RefRO<AttackRequest>,
                    EnabledRefRW<AttackEvent>,
                    RefRW<AttackCooldown>,
                    RefRW<AttackDelay>,
                    RefRO<AttackDistance>,
                    RefRO<Damage>>()
                    .WithPresent<Swordman>()
                    .WithPresent<AttackEvent>()
                    .WithEntityAccess()
            )
            {
                attackDelay.ValueRW.Time -= deltaTime;

                if (attackDelay.ValueRW.Time > 0f)
                {
                    continue;
                }

                // Request
                requestEnabled.ValueRW = false;

                // Condition
                var target = request.ValueRO.Target;

                if (target == Entity.Null
                    || !SystemAPI.Exists(target)
                    || !_transformLookup.TryGetComponent(target, out var targetTransform)
                    || !_healthLookup.TryGetComponent(target, out var healthTarget)
                    || healthTarget.IsDead())
                {
                    continue;
                }

                if(!_transformLookup.TryGetComponent(entity, out var transform)
                    || !_healthLookup.TryGetComponent(entity, out var health)
                    || health.IsDead()
                    || attackCooldown.ValueRO.IsPlaying())
                {
                    continue;
                }

                if (!_teamLookup.TryGetComponent(target, out var targetTeam)
                    || !_teamLookup.TryGetComponent(entity, out var team)
                    || targetTeam.Value == team.Value)
                {
                    continue;
                }

                float distance = attackDistance.ValueRO.Value;
                float3 delta = targetTransform.Position - transform.Position;

                if (math.lengthsq(delta) > distance * distance)
                {
                    continue;
                }

                // Action
                if (!_takeDamageRequestLookup.TryGetBuffer(target, out var requests))
                {
                    continue;
                }

                requests.Add(
                    new TakeDamageRequest
                    {
                        Damage = damage.ValueRO.Value,
                        Instigator = entity
                    }
                );

                attackCooldown.ValueRW.ResetTime();

                // Event
                eventEnabled.ValueRW = true;
            }
        }
    }
}