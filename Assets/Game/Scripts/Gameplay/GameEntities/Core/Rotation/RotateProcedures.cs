using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class RotateProcedures
    {
        public static void RotateStep(this IGameEntity entity, Vector3 direction, float deltaTime)
        {
            var rotation = entity.GetRotation();
            var speed = entity.GetRotateSpeed();
            var target = Quaternion.LookRotation(direction, Vector3.up);
            rotation.Value = Quaternion.RotateTowards(rotation.Value, target, speed.Value * deltaTime);
        }
    }
}