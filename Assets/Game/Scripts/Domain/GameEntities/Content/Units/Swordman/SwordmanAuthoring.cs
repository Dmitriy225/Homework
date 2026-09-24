using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SwordmanAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<SwordmanAuthoring>
        {
            public override void Bake(SwordmanAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Swordman>(entity);
            }
        }
    }
}