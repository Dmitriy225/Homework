using Unity.Mathematics;
using Unity.Transforms;

namespace SampleGame
{
    public static class MoveUseCase
    {
        public static bool MoveStep(
            ref LocalTransform transform,
            in float3 direction,
            in MoveSpeed speed,
            in float deltaTime
        )
        {
            if (!math.all(direction == float3.zero))
            {
                transform.Position += direction * (speed.Value * deltaTime);
                return true;
            }

            return false;
        }
    }
}