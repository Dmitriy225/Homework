using System;
using Unity.Entities;

namespace SampleGame
{
    [InternalBufferCapacity(4)]
    public struct TakeDamageEvent : IBufferElementData
    {
        public int Damage;
        public Entity Instigator;
    }
}