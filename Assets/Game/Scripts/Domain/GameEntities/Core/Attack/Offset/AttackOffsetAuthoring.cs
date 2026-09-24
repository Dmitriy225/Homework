using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackOffsetAuthoring : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;

        private sealed class Baker : Baker<AttackOffsetAuthoring>
        {
            public override void Bake(AttackOffsetAuthoring authoring)
            {
                Entity entity = this.GetEntity(TransformUsageFlags.None);
                this.AddComponent(entity, new AttackOffset
                {
                    Value = authoring._firePoint.position - authoring.transform.position
                });
            }
        }
    }
}