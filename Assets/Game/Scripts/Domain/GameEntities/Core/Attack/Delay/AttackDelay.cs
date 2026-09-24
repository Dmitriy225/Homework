using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    public struct AttackDelay : IComponentData
    {
        public float Time;
        public float Duration;
    }
}