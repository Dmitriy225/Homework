using Modules.AudioEvents;
using Unity.Entities;
using Unity.Transforms;

namespace SampleGame
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct AttackSfxSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            AudioSystem audioSystem = AudioSystem.Instance;
            
            foreach ((RefRO<LocalTransform> transformRef, RefRO<AttackSfxReference> sfxRef)
                     in SystemAPI.Query<RefRO<LocalTransform>, RefRO<AttackSfxReference>>()
                     .WithAll<AttackEvent>())
            {
                ref readonly AttackSfxReference sfx = ref sfxRef.ValueRO;
                ref readonly LocalTransform transform = ref transformRef.ValueRO;
                audioSystem.PlayEvent(
                    new AudioEventKey(sfx.EventId.ToString()),
                    transform.Position,
                    transform.Rotation,
                    sfx.Threshold
                );
            }
        }
    }
}