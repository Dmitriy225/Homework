using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveEventAuthoring : MonoBehaviour
    {
        private sealed class Baker : Baker<MoveEventAuthoring>
        {
            public override void Bake(MoveEventAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);
                AddComponent<MoveEvent>(entity);
                SetComponentEnabled<MoveEvent>(entity, false);
            }
        }
    }
}