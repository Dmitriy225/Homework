using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct MoneyCooldown : IComponentData
    {
        public float Time;
        public float Duration;
    }
}