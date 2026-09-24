using System;
using Unity.Entities;

namespace SampleGame
{
    public struct TargetEntity : IComponentData
    {
        public Entity Value;
    }
}