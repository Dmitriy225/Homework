using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DamageableTagAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<DamageableTagAuthoring>
        {
            public override void Bake(DamageableTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<DamageableTag>(entity);
            }
        }
    }
}