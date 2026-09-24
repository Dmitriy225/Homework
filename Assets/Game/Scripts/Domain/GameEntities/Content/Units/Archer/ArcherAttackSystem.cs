using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    [BurstCompile]
    public partial struct ArcherAttackSystem : ISystem
    {
        private ComponentLookup<LocalTransform> _transformLookup;
        private ComponentLookup<Team> _teamLookup;
        private ComponentLookup<Health> _healthLookup;
        private ComponentLookup<ArrowPrefab> _arrowPrefabLookup;
        private ComponentLookup<Ammo> _ammoLookup;
        private ComponentLookup<AttackOffset> _offsetLookup;
        private BufferLookup<TakeDamageRequest> _takeDamageRequestLookup;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
            _transformLookup = SystemAPI.GetComponentLookup<LocalTransform>(isReadOnly: true);
            _teamLookup = SystemAPI.GetComponentLookup<Team>(isReadOnly: true);
            _healthLookup = SystemAPI.GetComponentLookup<Health>(isReadOnly: true);
            _arrowPrefabLookup = SystemAPI.GetComponentLookup<ArrowPrefab>(isReadOnly: true);
            _ammoLookup = SystemAPI.GetComponentLookup<Ammo>();
            _offsetLookup = SystemAPI.GetComponentLookup<AttackOffset>(true);
            _takeDamageRequestLookup = SystemAPI.GetBufferLookup<TakeDamageRequest>(isReadOnly: false);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            _transformLookup.Update(ref state);
            _teamLookup.Update(ref state);
            _healthLookup.Update(ref state);
            _arrowPrefabLookup.Update(ref state);
            _ammoLookup.Update(ref state);
            _offsetLookup.Update(ref state);
            _takeDamageRequestLookup.Update(ref state);

            EntityCommandBuffer ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged);

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
                    .WithPresent<Archer>()
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

                if (!_ammoLookup.TryGetComponent(entity, out var ammo)
                    || ammo.Value <= 0)
                {
                    continue;
                }

                if (!_transformLookup.TryGetComponent(entity, out var transform)
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

                RefRO<ArrowPrefab> arrowPrefab = _arrowPrefabLookup.GetRefRO(entity);
                RefRO<AttackOffset> attackOffset = _offsetLookup.GetRefRO(entity);

                // Action
                transform.Rotation = quaternion.LookRotation(math.normalize(delta), math.up());

                ArrowUseCase.SpawnProjectile(
                    ref ecb,
                    arrowPrefab.ValueRO,
                    transform,
                    attackOffset.ValueRO,
                    team,
                    target
                );

                attackCooldown.ValueRW.ResetTime();
                ammo.Value--;

                // Event
                eventEnabled.ValueRW = true;
            }
        }
    }
}