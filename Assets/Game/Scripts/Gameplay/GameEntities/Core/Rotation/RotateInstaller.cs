using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class RotateInstaller : IEntityInstaller<IGameEntity>
    {
        public void Install(IGameEntity entity)
        {
            entity.AddRotateRequest(new Request<Vector3>());
            entity.AddRotateCondition(new AndExpression<Vector3>());
            entity.AddRotateAction(new CompositeAction<Vector3, float>());
            entity.AddRotateEvent(new Event<Vector3>());
            entity.AddBehaviour<RotateBehaviour>();
        }
    }
}