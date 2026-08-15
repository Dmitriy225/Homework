using System;
using UnityEngine;

namespace Game
{
    public static class TargetProcedures
    {
        public static bool AssignCharacterTarget(this IGameEntity entity, Collider collider)
        {
            return collider.TryGetComponent<IGameEntity>(out var targetEntity)
                && AssignCharacterTarget(entity, targetEntity);
        }

        public static bool AssignCharacterTarget(this IGameEntity entity, IGameEntity targetEntity)
        {
            return targetEntity.HasCharacterTag()
                && AssignTarget(entity, targetEntity);
        }

        public static bool AssignTarget(this IGameEntity entity, Collider collider)
        {
            return collider.TryGetComponent<IGameEntity>(out var targetEntity)
                && AssignTarget(entity, targetEntity);
        }

        public static bool AssignTarget(this IGameEntity entity, IGameEntity targetEntity)
        {
            if (!entity.TryGetTarget(out var target))
            {
                return false;
            }

            target.Value = targetEntity;
            return true;
        }

        public static bool RemoveTarget(this IGameEntity entity, Collider collider)
        {
            return collider.TryGetComponent<IGameEntity>(out var targetEntity)
                && RemoveTarget(entity, targetEntity);
        }

        public static bool RemoveTarget(this IGameEntity entity, IGameEntity targetEntity)
        {
            if (!entity.TryGetTarget(out var target)
                && target.Value != targetEntity)
            {
                return false;
            }

            target.Value = null;
            return true;
        }

        public static bool HasTarget(this IGameEntity entity, Collider collider)
        {
            return collider.TryGetComponent<IGameEntity>(out var targetEntity)
                && HasTarget(entity, targetEntity);
        }

        public static bool HasTarget(this IGameEntity entity, IGameEntity targetEntity)
        {
            return entity.TryGetTarget(out var target)
                && target.Value == targetEntity;
        }
    }
}