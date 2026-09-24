using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoneyCooldownAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        public sealed class Baker : Baker<MoneyCooldownAuthoring>
        {
            public override void Bake(MoneyCooldownAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new MoneyCooldown
                {
                    Time = authoring._duration,
                    Duration = authoring._duration
                });
            }
        }
    }
}