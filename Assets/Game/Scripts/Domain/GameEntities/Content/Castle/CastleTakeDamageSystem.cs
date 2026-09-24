using System;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace SampleGame
{
    [BurstCompile]
    public partial struct CastleTakeDamageSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (
                var (
                    health,
                    requests,
                    events)
                in SystemAPI.Query<
                    RefRW<Health>,
                    DynamicBuffer<TakeDamageRequest>,
                    DynamicBuffer<TakeDamageEvent>>()
                    .WithPresent<Castle>())
            {
                for (int i = 0; i < requests.Length && health.ValueRO.IsAlive(); i++)
                {
                    TakeDamageRequest request = requests[i];
                    health.ValueRW.Reduce(request.Damage);

                    events.Add(new TakeDamageEvent
                    {
                        Damage = request.Damage,
                        Instigator = request.Instigator
                    });
                    Debug.Log("LAG");
                }
                requests.Clear();
            }
        }
    }
}