using Modules.AudioEvents;
using System;
using Unity.Entities;
using Unity.Entities.HybridViews;
using UnityEngine;

namespace SampleGame
{
    public sealed class CastleView : EntityView
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private AudioEventSerialized _takeDamageSfxEvent;

        protected override void Show(Entity entity, EntityCommandBuffer ecb)
        {
            ecb.AddComponent(entity, new TransformReference
            {
                Value = _transform.transformHandle
            });

            ecb.AddComponent(entity, new TakeDamageSfxReference
            {
                EventId = _takeDamageSfxEvent.Key,
                Threshold = 0.1f
            });
        }

        protected override void Hide(Entity entity, EntityCommandBuffer ecb)
        {
        }
    }
}