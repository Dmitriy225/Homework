using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class StoppingDistanceAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        public sealed class Baker : Baker<StoppingDistanceAuthoring>
        {
            public override void Bake(StoppingDistanceAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new StoppingDistance { Value = authoring._value });
            }
        }
    }
}