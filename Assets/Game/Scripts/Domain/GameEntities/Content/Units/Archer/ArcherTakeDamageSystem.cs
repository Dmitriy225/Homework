using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace SampleGame
{
    [BurstCompile]
    public partial struct ArcherTakeDamageSystem : ISystem
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
                    .WithPresent<Archer>())
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
                }

                requests.Clear();
            }
        }
    }
}