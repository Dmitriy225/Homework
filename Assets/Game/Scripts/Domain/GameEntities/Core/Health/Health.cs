using Unity.Entities;

namespace SampleGame
{
    public struct Health : IComponentData
    {
        public int Current;
        public int Max;
    }
}