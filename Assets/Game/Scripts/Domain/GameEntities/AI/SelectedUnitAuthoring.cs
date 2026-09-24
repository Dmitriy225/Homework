using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SelectedUnitAuthoring : MonoBehaviour
    {
        public sealed class Baker : Baker<SelectedUnitAuthoring>
        {
            public override void Bake(SelectedUnitAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<SelectedUnit>(entity);
            }
        }
    }
}