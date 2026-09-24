using System;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public static class HealthUseCase
    {
        public static bool IsAlive(in this Health health)
        {
            return health.Current > 0;
        }

        public static bool IsDead(in this Health health)
        {
            return health.Current <= 0;
        }

        public static void Reduce(ref this Health health, int damage)
        {
            health.Current = math.max(0, health.Current - math.max(0, damage));
        }

        public static float GetPercent(in this Health health)
        {
            return health.Current / (float)health.Max;
        }
    }
}