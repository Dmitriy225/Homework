using Unity.Entities;

namespace SampleGame
{
    public struct Lifetime : IComponentData
    {
        public float Time;
        public float Duration;
    }
}