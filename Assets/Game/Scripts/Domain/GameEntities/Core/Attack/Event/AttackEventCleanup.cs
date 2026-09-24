using Unity.Burst;
using Unity.Entities;

namespace SampleGame
{
    [BurstCompile]
    [UpdateInGroup(typeof(CleanupSystemGroup))]
    public partial struct AttackEventCleanup : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (EnabledRefRW<AttackEvent> attackEvent in SystemAPI.Query<EnabledRefRW<AttackEvent>>())
            {
                attackEvent.ValueRW = false;
            }
        }
    }
}