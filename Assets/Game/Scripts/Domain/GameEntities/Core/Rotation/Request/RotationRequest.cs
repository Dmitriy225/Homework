using Unity.Entities;
using Unity.Mathematics;

namespace SampleGame
{
    public struct RotationRequest : IComponentData, IEnableableComponent
    {
        public float3 Direction;
    }
}