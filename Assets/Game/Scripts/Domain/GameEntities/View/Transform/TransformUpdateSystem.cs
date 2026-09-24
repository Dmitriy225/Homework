using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct TransformUpdateSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (
                (RefRO<LocalTransform> localTransform, RefRO<TransformReference> transformRef)
                in SystemAPI.Query<RefRO<LocalTransform>, RefRO<TransformReference>>()
            )
            {
                TransformHandle transform = transformRef.ValueRO.Value;
                transform.SetPositionAndRotation(localTransform.ValueRO.Position, localTransform.ValueRO.Rotation);
            }
        }
    }
}