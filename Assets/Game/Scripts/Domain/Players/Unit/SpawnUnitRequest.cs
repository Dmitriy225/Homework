using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct SpawnUnitRequest : IComponentData, IEnableableComponent
    {
        public FixedString64Bytes UnitName;
    }
}