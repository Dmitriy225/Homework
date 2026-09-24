using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DamageAuthoring : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public sealed class Baker : Baker<DamageAuthoring>
        {
            public override void Bake(DamageAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Damage { Value = authoring._value });
            }
        }
    }
}