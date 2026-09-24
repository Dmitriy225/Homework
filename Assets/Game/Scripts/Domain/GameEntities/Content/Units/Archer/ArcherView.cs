using Modules.AudioEvents;
using System;
using Unity.Entities;
using Unity.Entities.HybridViews;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArcherView : EntityView
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AudioEventSerialized _attackSfxEvent;

        protected override void Show(Entity entity, EntityCommandBuffer ecb)
        {
            ecb.AddComponent(entity, new TransformReference
            {
                Value = _transform.transformHandle
            });

            ecb.AddComponent(entity, new AnimatorReference
            {
                Value = _animator
            });

            ecb.AddComponent(entity, new AttackSfxReference
            {
                EventId = _attackSfxEvent.Key,
                Threshold = 0.1f
            });
        }

        protected override void Hide(Entity entity, EntityCommandBuffer ecb)
        {
        }
    }
}