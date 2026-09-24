using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArmorMultiplierAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        public sealed class Baker : Baker<ArmorMultiplierAuthoring>
        {
            public override void Bake(ArmorMultiplierAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new ArmorMultiplier { Value = authoring._value });
            }
        }
    }
}