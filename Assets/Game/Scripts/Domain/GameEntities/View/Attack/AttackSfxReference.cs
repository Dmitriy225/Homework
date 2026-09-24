using Modules.AudioEvents;
using Unity.Collections;
using Unity.Entities;

namespace SampleGame
{
    public struct AttackSfxReference : IComponentData
    {
        public FixedString32Bytes EventId;
        public float Threshold;
    }
}