using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SpawnUnitRequestAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<SpawnUnitRequestAuthoring>
        {
            public override void Bake(SpawnUnitRequestAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<SpawnUnitRequest>(entity);
                SetComponentEnabled<SpawnUnitRequest>(entity, false);
            }
        }
    }
}