using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CastleAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<CastleAuthoring>
        {
            public override void Bake(CastleAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<Castle>(entity);
            }
        }
    }
}