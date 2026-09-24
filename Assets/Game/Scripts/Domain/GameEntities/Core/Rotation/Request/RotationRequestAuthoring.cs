using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class RotationRequestAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<RotationRequestAuthoring>
        {
            public override void Bake(RotationRequestAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<RotationRequest>(entity);
                SetComponentEnabled<RotationRequest>(entity, false);
            }
        }
    }
}