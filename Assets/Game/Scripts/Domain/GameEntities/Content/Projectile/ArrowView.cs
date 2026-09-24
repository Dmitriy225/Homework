using System;
using Unity.Entities;
using Unity.Entities.HybridViews;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArrowView : EntityView
    {
        [SerializeField]
        private Transform _transform;

        protected override void Show(Entity entity, EntityCommandBuffer ecb)
        {
            ecb.AddComponent(entity, new TransformReference
            {
                Value = _transform.transformHandle
            });
        }

        protected override void Hide(Entity entity, EntityCommandBuffer ecb)
        {
            
        }
    }
}