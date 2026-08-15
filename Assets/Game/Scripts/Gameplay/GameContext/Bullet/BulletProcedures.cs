using System;
using UnityEngine;

namespace Game
{
    public static class BulletProcedures
    {
        public static void Rent(IGameContext context, GameEntity prefab, Vector3 position, Quaternion rotation)
        {
            var pool = context.GetBulletPool();
            pool.Rent(prefab, position, rotation);
        }

        public static void Return(IGameContext context, GameEntity entity)
        {
            var pool = context.GetBulletPool();
            pool.Return(entity);
        }
    }
}