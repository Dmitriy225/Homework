using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct UnitConfigBuffer : IBufferElementData
    {
        public FixedString64Bytes Name;
        public int Price;
        public Entity Prefab;
    }
}