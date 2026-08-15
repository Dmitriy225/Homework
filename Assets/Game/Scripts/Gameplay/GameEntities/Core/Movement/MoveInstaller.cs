using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class MoveInstaller : IEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Cooldown _postCooldown;

        public void Install(IGameEntity entity)
        {
            entity.AddMoveRequest(new Request<Vector3>());
            entity.AddMoveCondition(new AndExpression<Vector3>());
            entity.AddMoveAction(new CompositeAction<Vector3, float>());
            entity.AddMoveEvent(new Event<Vector3>());
            entity.AddPostMoveCooldown(_postCooldown);
            entity.AddBehaviour<MoveBehaviour>();
        }
    }
}