using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace SampleGame
{
    [BurstCompile]
    public partial struct SwordmanTakeDamageSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (
                var (
                    health,
                    requests,
                    events,
                    armor)
                in SystemAPI.Query<
                    RefRW<Health>,
                    DynamicBuffer<TakeDamageRequest>,
                    DynamicBuffer<TakeDamageEvent>,
                    RefRO<ArmorMultiplier>>()
                    .WithPresent<Swordman>())
            {
                for (int i = 0; i < requests.Length && health.ValueRO.IsAlive(); i++)
                {
                    TakeDamageRequest request = requests[i];
                    int damage = (int)math.round(request.Damage * (1f - armor.ValueRO.Value));
                    health.ValueRW.Reduce(damage);

                    events.Add(new TakeDamageEvent
                    {
                        Damage = damage,
                        Instigator = request.Instigator
                    });
                }

                requests.Clear();
            }
        }
    }
}