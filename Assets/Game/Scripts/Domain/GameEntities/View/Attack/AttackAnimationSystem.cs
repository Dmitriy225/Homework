using SampleGame;
using System;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct AttackAnimationSystem : ISystem
    {
        private static readonly int Fire = Animator.StringToHash("Fire");

        public void OnUpdate(ref SystemState state)
        {
            foreach (
                RefRO<AnimatorReference> animatorRef in SystemAPI.Query<RefRO<AnimatorReference>>()
                    .WithAll<AttackEvent>()
            )
            {
                Animator animator = animatorRef.ValueRO.Value.Value;
                animator.SetTrigger(Fire);
            }
        }
    }
}