using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct DeathAnimationSystem : ISystem
    {
        private static readonly int Death = Animator.StringToHash("Death");

        public void OnUpdate(ref SystemState state)
        {
            foreach (
                RefRO<AnimatorReference> animatorRef in SystemAPI.Query<RefRO<AnimatorReference>>()
                    .WithAll<DeathEvent>()
            )
            {
                Animator animator = animatorRef.ValueRO.Value.Value;
                animator.SetTrigger(Death);
            }
        }
    }
}