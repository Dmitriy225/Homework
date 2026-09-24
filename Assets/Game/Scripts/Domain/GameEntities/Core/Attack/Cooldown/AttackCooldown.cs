using System;
using Unity.Entities;

namespace SampleGame
{
    [Serializable]
    public struct AttackCooldown : IComponentData
    {
        public float Time;
        public float Duration;
    }
}