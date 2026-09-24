using Unity.Entities;
using Unity.Mathematics;

namespace SampleGame
{
    public struct MoveRequest : IComponentData, IEnableableComponent
    {
        public float3 Direction;
    }
}