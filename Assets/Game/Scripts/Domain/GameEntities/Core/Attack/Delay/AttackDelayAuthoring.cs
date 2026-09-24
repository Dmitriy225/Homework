using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackDelayAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        public sealed class Baker : Baker<AttackDelayAuthoring>
        {
            public override void Bake(AttackDelayAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(
                    entity,
                    new AttackDelay
                    {
                        Time = authoring._duration,
                        Duration = authoring._duration
                    }
                );
            }
        }
    }
}