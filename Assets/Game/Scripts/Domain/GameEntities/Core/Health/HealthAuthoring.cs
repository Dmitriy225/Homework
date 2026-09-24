using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class HealthAuthoring : MonoBehaviour
    {
        [SerializeField]
        private int _value;

        public sealed class Baker : Baker<HealthAuthoring>
        {
            public override void Bake(HealthAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Health
                {
                    Current = authoring._value,
                    Max = authoring._value
                });
            }
        }
    }
}