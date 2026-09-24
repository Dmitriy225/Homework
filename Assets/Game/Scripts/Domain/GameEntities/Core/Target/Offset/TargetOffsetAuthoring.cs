using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public sealed class TargetOffsetAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float3 _value;

        public sealed class Baker : Baker<TargetOffsetAuthoring>
        {
            public override void Bake(TargetOffsetAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new TargetOffset { Value = authoring._value });
            }
        }
    }
}