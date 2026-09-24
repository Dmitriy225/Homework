using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class PlayerAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<Player>(entity);
            }
        }
    }
}