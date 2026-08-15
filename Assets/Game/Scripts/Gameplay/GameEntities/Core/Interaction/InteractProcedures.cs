using System;
using UnityEngine;

namespace Game
{
    public static class InteractProcedures
    {
        public static void InteractWith(this IGameEntity entity, Collider collider)
        {
            if (collider.TryGetComponent<IGameEntity>(out var interactable))
            {
                InteractWith(entity, interactable);
            }
        }

        public static void InteractWith(this IGameEntity entity, IGameEntity interactable)
        {
            if (interactable.HasInteractableTag()
                && interactable.GetInteractCondition().Invoke(entity))
            {
                interactable.GetInteractAction().Invoke(entity);
                interactable.GetInteractEvent().Invoke(entity);
            }
        }
    }
}