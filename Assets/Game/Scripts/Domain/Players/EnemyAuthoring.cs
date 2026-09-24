using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class EnemyAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<Enemy>(entity);
            }
        }
    }
}