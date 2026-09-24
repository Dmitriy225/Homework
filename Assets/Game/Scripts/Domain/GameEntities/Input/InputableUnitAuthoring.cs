using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class InputableUnitAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<InputableUnitAuthoring>
        {
            public override void Bake(InputableUnitAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<InputableUnit>(entity);
            }
        }
    }
}