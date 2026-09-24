using Unity.Entities;

namespace SampleGame
{
    public struct Team : IComponentData
    {
        public TeamType Value;
    }
}