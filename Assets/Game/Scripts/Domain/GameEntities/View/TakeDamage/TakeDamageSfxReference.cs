using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct TakeDamageSfxReference : IComponentData
    {
        public FixedString32Bytes EventId;
        public float Threshold;
    }
}