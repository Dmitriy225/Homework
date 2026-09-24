using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackRequestAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<AttackRequestAuthoring>
        {
            public override void Bake(AttackRequestAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<AttackRequest>(entity);
                SetComponentEnabled<AttackRequest>(entity, false);
            }
        }
    }
}