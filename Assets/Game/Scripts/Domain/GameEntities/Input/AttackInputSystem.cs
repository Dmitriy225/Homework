using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    //[DisableAutoCreation]
    //public partial class AttackInputSystem : SystemBase
    //{
    //    protected override void OnUpdate()
    //    {
    //        if (!Input.GetKeyDown(KeyCode.Mouse0))
    //        {
    //            return;
    //        }

    //        foreach (
    //            var (request, requestEnabled, target)
    //            in SystemAPI.Query<RefRW<AttackRequest>, EnabledRefRW<AttackRequest>, RefRO<TargetEntity>>()
    //            .WithPresent<InputableUnit, AttackRequest>()
    //        )
    //        {
    //            requestEnabled.ValueRW = true;
    //            request.ValueRW.Target = target.ValueRO.Value;
    //        }
    //    }
    //}
}