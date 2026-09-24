using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AmmoAuthoring : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public sealed class Baker : Baker<AmmoAuthoring>
        {
            public override void Bake(AmmoAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Ammo { Value = authoring._value });
            }
        }
    }
}