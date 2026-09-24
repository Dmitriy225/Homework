using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class LifetimeAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        public sealed class Baker : Baker<LifetimeAuthoring>
        {
            public override void Bake(LifetimeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(
                    entity,
                    new Lifetime
                    {
                        Time = authoring._duration,
                        Duration = authoring._duration
                    }
                );
            }
        }
    }
}