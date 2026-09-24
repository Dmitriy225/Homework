using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    // TODO: Разобраться с Job

    //[BurstCompile]
    //public partial struct DetectTargetSystem : ISystem
    //{
    //    private ComponentLookup<LocalTransform> _transformLookup;
    //    private ComponentLookup<Team> _teamLookup;
    //    private ComponentLookup<Health> _healthLookup;

    //    public void OnCreate(ref SystemState state)
    //    {
    //        _transformLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
    //        _teamLookup = state.GetComponentLookup<Team>(isReadOnly: true);
    //        _healthLookup = state.GetComponentLookup<Health>(isReadOnly: true);

    //        state.RequireForUpdate<SpatialHashData>();
    //    }

    //    [BurstCompile]
    //    public void OnUpdate(ref SystemState state)
    //    {
    //        _transformLookup.Update(ref state);
    //        _teamLookup.Update(ref state);
    //        _healthLookup.Update(ref state);

    //        state.Dependency = new DetectJob
    //        {
    //            SpatialHash = SystemAPI.GetSingleton<SpatialHashData>(),
    //            TransformLookup = _transformLookup,
    //            TeamLookup = _teamLookup,
    //            HealthLookup = _healthLookup,
    //        }.ScheduleParallel(state.Dependency);
    //    }

    //    [WithPresent(typeof(Unit))]
    //    [BurstCompile]
    //    public partial struct DetectJob : IJobEntity
    //    {
    //        [NativeDisableUnsafePtrRestriction]
    //        public SpatialHashData SpatialHash;

    //        [ReadOnly]
    //        public ComponentLookup<LocalTransform> TransformLookup;

    //        [ReadOnly]
    //        public ComponentLookup<Team> TeamLookup;

    //        [ReadOnly]
    //        public ComponentLookup<Health> HealthLookup;

    //        private void Execute(
    //            Entity entity,
    //            in LocalTransform transform,
    //            in Team team,
    //            in DetectionRadius detectionRadius,
    //            ref TargetEntity target
    //        )
    //        {
    //            IsEnemyPredicate condition = new IsEnemyPredicate(
    //                entity,
    //                team.Value,
    //                TeamLookup,
    //                HealthLookup
    //            );

    //            target.Value = SpatialHash.FindClosest(
    //                transform.Position,
    //                detectionRadius.Value,
    //                in condition,
    //                TransformLookup
    //            );

    //            //if (target.Value == Entity.Null)
    //            //{
    //            //    UnityEngine.Debug.Log($"Entity {entity.Index} found no targets");
    //            //}
    //        }
    //    }
    //}

    [BurstCompile]
    public partial struct DetectTargetSystem : ISystem
    {
        private ComponentLookup<LocalTransform> _transformLookup;
        private ComponentLookup<Team> _teamLookup;
        private ComponentLookup<Health> _healthLookup;

        public void OnCreate(ref SystemState state)
        {
            _transformLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
            _teamLookup = state.GetComponentLookup<Team>(isReadOnly: true);
            _healthLookup = state.GetComponentLookup<Health>(isReadOnly: true);

            state.RequireForUpdate<SpatialHashData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _transformLookup.Update(ref state);
            _teamLookup.Update(ref state);
            _healthLookup.Update(ref state);

            var spatialHash = SystemAPI.GetSingleton<SpatialHashData>();

            foreach (
                var (
                    transform,
                    team,
                    radius,
                    target,
                    entity)
                in SystemAPI.Query<
                    LocalTransform,
                    Team,
                    DetectionRadius,
                    TargetEntity>()
                    .WithPresent<Unit>()
                    .WithEntityAccess()
            )
            {
                var condition = new IsEnemyPredicate(
                    entity,
                    team.Value,
                    _teamLookup,
                    _healthLookup
                );

                var newTarget = spatialHash.FindClosest(
                    transform.Position,
                    radius.Value,
                    in condition,
                    _transformLookup
                );

                if (target.Value != newTarget)
                {
                    SystemAPI.SetComponent(entity, new TargetEntity { Value = newTarget });
                }
            }
        }
    }
}