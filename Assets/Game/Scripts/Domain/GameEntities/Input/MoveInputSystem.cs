using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [DisableAutoCreation]
    public partial class MoveInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float dx = Input.GetAxis("Horizontal");
            float dz = Input.GetAxis("Vertical");

            float3 moveDirection = new float3(dx, 0, dz);

            foreach (
                var (request, requestEnabled)
                in SystemAPI.Query<RefRW<MoveRequest>, EnabledRefRW<MoveRequest>>()
                .WithPresent<InputableUnit, MoveRequest>()
            )
            {
                requestEnabled.ValueRW = true;
                request.ValueRW.Direction = moveDirection;
            }
        }
    }
}