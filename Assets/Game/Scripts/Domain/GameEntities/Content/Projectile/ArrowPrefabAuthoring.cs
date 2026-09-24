using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArrowPrefabAuthoring : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        
        private sealed class Baker : Baker<ArrowPrefabAuthoring>
        {
            public override void Bake(ArrowPrefabAuthoring authoring)
            {
                Entity entity = this.GetEntity(TransformUsageFlags.None);
                this.AddComponent(entity, new ArrowPrefab
                {
                    Value = this.GetEntity(authoring._prefab, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}