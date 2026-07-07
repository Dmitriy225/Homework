using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private Health _health;

        [SerializeField]
        private Const<float> _moveSpeed;

        [SerializeField]
        private Const<float> _rotateSpeed;

        public override void Install(IEntity entity)
        {
            entity.AddPosition(
                new InlineVariable<Vector3>(
                    () => transform.position,
                    position => transform.position = position
                )
            );
            entity.AddRotation(
                new InlineVariable<Quaternion>(
                    () => transform.rotation,
                    rotation => transform.rotation = rotation
                )
            );
            entity.AddHealth(_health);

            entity.Install(new MoveInstaller());
            entity.GetMoveCondition().Add(_ => entity.GetHealth().IsNotEmpty);
            entity.GetMoveAction().Add(entity.MoveStep);
            entity.GetMoveAction().Add(entity.RotateStep);
            entity.AddMoveSpeed(_moveSpeed);

            entity.Install(new RotateInstaller());
            entity.GetRotateCondition().Add(_ => entity.GetHealth().IsNotEmpty);
            entity.GetRotateAction().Add(entity.RotateStep);
            entity.AddRotateSpeed(_rotateSpeed);
        }
    }
}