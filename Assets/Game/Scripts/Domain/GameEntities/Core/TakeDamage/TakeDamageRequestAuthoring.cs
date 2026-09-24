using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class TakeDamageRequestAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<TakeDamageRequestAuthoring>
        {
            public override void Bake(TakeDamageRequestAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddBuffer<TakeDamageRequest>(entity);
            }
        }
    }
}