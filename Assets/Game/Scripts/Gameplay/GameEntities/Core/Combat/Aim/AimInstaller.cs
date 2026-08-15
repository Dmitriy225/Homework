using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class AimInstaller : IEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private DownTimer _postTimer;

        public void Install(IGameEntity entity)
        {
            entity.AddAimRequest(new Request<Vector3>());
            entity.AddAimCondition(new AndExpression<Vector3>());
            entity.AddAimAction(new CompositeAction<Vector3, float>());
            entity.AddAimEvent(new Event<Vector3>());
            entity.AddPostAimTimer(_postTimer);
            entity.AddBehaviour<AimBehaviour>();
        }
    }
}