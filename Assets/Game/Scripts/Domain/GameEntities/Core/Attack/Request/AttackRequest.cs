using Unity.Entities;

namespace SampleGame
{
    public struct AttackRequest : IComponentData, IEnableableComponent
    {
        public Entity Target;
    }
}