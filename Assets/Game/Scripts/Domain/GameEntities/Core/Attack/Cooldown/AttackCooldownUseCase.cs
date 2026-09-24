using Unity.Mathematics;

namespace SampleGame
{
    public static class AttackCooldownUseCase
    {
        public static bool IsPlaying(in this AttackCooldown cooldown)
        {
            return cooldown.Time > 0;
        }

        public static bool IsExpired(in this AttackCooldown cooldown)
        {
            return cooldown.Time <= 0;
        }

        public static void ResetTime(ref this AttackCooldown cooldown)
        {
            cooldown.Time = cooldown.Duration;
        }

        public static void Tick(ref this AttackCooldown cooldown, in float deltaTime)
        {
            cooldown.Time = math.max(0, cooldown.Time - deltaTime);
        }
    }
}