using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveSpeedAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        public sealed class Baker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new MoveSpeed { Value = authoring._value });
            }
        }
    }
}