using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace Game
{
    public sealed class FireAnimDrivenInstaller : IEntityInstaller<IGameEntity>
    {
        public void Install(IGameEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCondition(new AndExpression());
            entity.AddFireAnimDrivenEvent(new Event());
            entity.AddFireAction(new CompositeAction());
            entity.AddFireEvent(new Event());
            entity.AddBehaviour<FireAnimDrivenBehaviour>();
        }
    }
}