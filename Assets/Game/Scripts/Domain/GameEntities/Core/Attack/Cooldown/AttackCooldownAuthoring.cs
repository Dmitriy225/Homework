using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackCooldownAuthoring : MonoBehaviour
    {
        [SerializeField]
        private AttackCooldown _cooldown;

        public sealed class Baker : Baker<AttackCooldownAuthoring>
        {
            public override void Bake(AttackCooldownAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, authoring._cooldown);
            }
        }
    }
}