using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveRequestAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<MoveRequestAuthoring>
        {
            public override void Bake(MoveRequestAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new MoveRequest { Direction = float3.zero });
                SetComponentEnabled<MoveRequest>(entity, false);
            }
        }
    }
}