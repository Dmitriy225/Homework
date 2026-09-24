using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArrowAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<ArrowAuthoring>
        {
            public override void Bake(ArrowAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<Arrow>(entity);
            }
        }
    }
}