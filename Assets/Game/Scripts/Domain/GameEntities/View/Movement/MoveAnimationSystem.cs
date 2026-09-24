using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct MoveAnimationSystem : ISystem
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public void OnUpdate(ref SystemState state)
        {
            foreach (
                (EnabledRefRO<MoveEvent> eventEnabled, RefRO<AnimatorReference> animatorRef)
                in SystemAPI.Query<EnabledRefRO<MoveEvent>, RefRO<AnimatorReference>>()
                    .WithPresent<MoveEvent>()
            )
            {
                Animator animator = animatorRef.ValueRO.Value.Value;
                animator.SetBool(IsMoving, eventEnabled.ValueRO);
            }
        }
    }
}