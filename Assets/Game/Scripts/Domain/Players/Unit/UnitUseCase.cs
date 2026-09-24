using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    public static class UnitUseCase
    {
        private static int FindConfigIndex(
            in DynamicBuffer<UnitConfigBuffer> configBuffer,
            in FixedString64Bytes name)
        {
            for (int i = 0; i < configBuffer.Length; i++)
            {
                if (configBuffer[i].Name == name)
                    return i;
            }
            return -1;
        }

        public static bool CanBuyUnit(
            in Money money,
            in DynamicBuffer<UnitConfigBuffer> configBuffer,
            in FixedString64Bytes name)
        {
            int index = FindConfigIndex(configBuffer, name);
            if (index < 0)
                return false;

            return money.Value >= configBuffer[index].Price;
        }

        public static bool BuyUnit(
            ref EntityCommandBuffer ecb,
            ref Money money,
            in DynamicBuffer<UnitConfigBuffer> configBuffer,
            in FixedString64Bytes name,
            in float3 position,
            in Team team)
        {
            int index = FindConfigIndex(configBuffer, name);
            if (index < 0)
                return false;

            var config = configBuffer[index];

            if (money.Value < config.Price)
                return false;

            money.Value -= config.Price;

            SpawnUnit(ref ecb, config.Prefab, position, team);

            return true;
        }

        public static bool SpawnUnit(
            ref EntityCommandBuffer ecb,
            in DynamicBuffer<UnitConfigBuffer> configBuffer,
            in FixedString64Bytes name,
            in float3 position,
            in Team team)
        {
            int index = FindConfigIndex(configBuffer, name);
            if (index < 0)
                return false;

            SpawnUnit(ref ecb, configBuffer[index].Prefab, position, team);
            return true;
        }

        public static void SpawnUnit(
            ref EntityCommandBuffer ecb,
            Entity prefab,
            in float3 position,
            in Team team)
        {
            if (prefab == Entity.Null)
                return;

            Entity unit = ecb.Instantiate(prefab);
            ecb.SetComponent(unit, LocalTransform.FromPosition(position));
            ecb.SetComponent(unit, team);
        }
    }
}