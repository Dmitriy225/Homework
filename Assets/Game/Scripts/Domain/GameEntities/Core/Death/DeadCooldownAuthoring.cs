using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public class DeadCooldownAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        public sealed class Baker : Baker<DeadCooldownAuthoring>
        {
            public override void Bake(DeadCooldownAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new DeadCooldown {Duration = authoring._duration});
                SetComponentEnabled<DeadCooldown>(entity, false);
            }
        }
    }
}