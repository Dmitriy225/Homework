using Modules.AudioEvents;
using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace SampleGame
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct TakeDamageSfxSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            AudioSystem audioSystem = AudioSystem.Instance;

            foreach (
                (
                    RefRO<LocalTransform> transformRef,
                    RefRO<TakeDamageSfxReference> sfxRef,
                    DynamicBuffer<TakeDamageEvent> takeDamageEventBuffer
                ) in SystemAPI.Query<
                    RefRO<LocalTransform>,
                    RefRO<TakeDamageSfxReference>,
                    DynamicBuffer<TakeDamageEvent>
                >()
            )
            {
                for (int i = 0; i < takeDamageEventBuffer.Length; i++)
                {
                    ref readonly TakeDamageSfxReference sfx = ref sfxRef.ValueRO;
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
}