using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MovableAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<MovableAuthoring>
        {
            public override void Bake(MovableAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Movable>(entity);
            }
        }
    }
}