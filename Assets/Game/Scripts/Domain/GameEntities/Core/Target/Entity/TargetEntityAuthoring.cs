using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class TargetEntityAuthoring : MonoBehaviour
    {
        [SerializeField]
        private GameObject _target;

        public sealed class Baker : Baker<TargetEntityAuthoring>
        {
            public override void Bake(TargetEntityAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(
                    entity,
                    new TargetEntity
                    {
                        Value = GetEntity(authoring._target, TransformUsageFlags.None) 
                    }
                );
            }
        }
    }
}