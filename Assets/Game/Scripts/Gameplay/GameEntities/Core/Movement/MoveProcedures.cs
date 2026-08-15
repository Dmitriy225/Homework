using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class MoveProcedures
    {
        public static void MoveStep(this IGameEntity entity, Vector3 direction, float deltaTime)
        {
            var position = entity.GetPosition();
            var speed = entity.GetMoveSpeed();
            position.Value += speed.Value * deltaTime * direction.normalized;
        }
    }
}