using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoneyAuthoring : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public sealed class Baker : Baker<MoneyAuthoring>
        {
            public override void Bake(MoneyAuthoring authoring)
            {
                var context = GetEntity(TransformUsageFlags.None);
                AddComponent(context, new Money { Value = authoring._value });
            }
        }
    }
}