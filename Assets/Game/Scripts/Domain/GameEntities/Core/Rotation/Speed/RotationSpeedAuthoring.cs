using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class RotationSpeedAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        public sealed class Baker : Baker<RotationSpeedAuthoring>
        {
            public override void Bake(RotationSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new RotationSpeed { Value = authoring._speed });
            }
        }
    }
}