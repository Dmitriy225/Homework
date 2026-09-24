using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArcherAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<ArcherAuthoring>
        {
            public override void Bake(ArcherAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Archer>(entity);
            }
        }
    }
}