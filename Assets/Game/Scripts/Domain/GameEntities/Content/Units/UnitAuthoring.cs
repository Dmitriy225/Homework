using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<UnitAuthoring>
        {
            public override void Bake(UnitAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Unit>(entity);
            }
        }
    }
}