using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackDistanceAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        public sealed class Baker : Baker<AttackDistanceAuthoring>
        {
            public override void Bake(AttackDistanceAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new AttackDistance { Value = authoring._value });
            }
        }
    }
}