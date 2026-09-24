using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct ArmorMultiplier : IComponentData
    {
        public float Value;
    }
}