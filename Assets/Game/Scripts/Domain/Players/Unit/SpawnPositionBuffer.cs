using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [InternalBufferCapacity(4)]
    public struct SpawnPositionBuffer : IBufferElementData
    {
        public float3 Position;
    }
}