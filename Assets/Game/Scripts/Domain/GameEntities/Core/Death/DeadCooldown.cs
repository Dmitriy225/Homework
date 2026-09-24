using Unity.Entities;

namespace SampleGame
{
    public struct DeadCooldown : IComponentData, IEnableableComponent
    {
        public float Time;
        public float Duration;
    }
}