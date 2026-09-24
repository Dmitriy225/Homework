using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public struct AttackOffset : IComponentData
    {
        public float3 Value;
    }
}