using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class MoveInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddMoveRequest(new Request<Vector3>());
            entity.AddMoveCondition(new AndExpression<Vector3>());
            entity.AddMoveAction(new CompositeAction<Vector3, float>());
            entity.AddMoveEvent(new Event<Vector3>());
            entity.AddBehaviour<MoveBehaviour>();
        }
    }
}