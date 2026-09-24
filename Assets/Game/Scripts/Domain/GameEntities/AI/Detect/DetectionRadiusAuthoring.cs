using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DetectionRadiusAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        public sealed class Baker : Baker<DetectionRadiusAuthoring>
        {
            public override void Bake(DetectionRadiusAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new DetectionRadius { Value = authoring._value });
            }
        }
    }
}