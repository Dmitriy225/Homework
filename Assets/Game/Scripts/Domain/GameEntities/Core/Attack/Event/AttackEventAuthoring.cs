using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackEventAuthoring : MonoBehaviour
    {
        private sealed class Baker : Baker<AttackEventAuthoring>
        {
            public override void Bake(AttackEventAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<AttackEvent>(entity);
                SetComponentEnabled<AttackEvent>(entity, false);
            }
        }
    }
}