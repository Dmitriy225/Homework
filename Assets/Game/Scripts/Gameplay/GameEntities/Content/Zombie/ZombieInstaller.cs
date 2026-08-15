using Atomic.Entities;
using Atomic.Elements;
using Game;
using System;
using UnityEngine;

namespace Game
{
    public sealed class ZombieInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Health _health;

        [SerializeField]
        private MoveInstaller _moveInstaller;

        [SerializeField]
        private Const<float> _moveSpeed;

        [SerializeField]
        private Const<float> _rotateSpeed;

        [SerializeField]
        private Const<GameEntity> _weapon;

        [SerializeField]
        private CollisionEvents _collisionEvents;

        [SerializeField]
        private AnimationEvents _animEvents;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IGameEntity entity)
        {
            var gameContext = GameContext.Instance;
            entity.Install(new TransformInstaller(_transform));

            entity.AddHealth(_health);
            entity.AddTarget(new ReactiveVariable<IGameEntity>());
            entity.AddBehaviour<FollowTargetBehaviour>();
            entity.AddCollisionEvents(_collisionEvents);
            entity.AddAnimEvents(_animEvents);

            entity.AddRotateSpeed(_rotateSpeed);
            entity.Install(_moveInstaller);
            entity.GetMoveCondition().Add(_ => entity.GetHealth().IsNotEmpty);
            entity.GetMoveAction().Add(entity.RotateStep);

            entity.AddWeapon(_weapon);
            entity.Install(new FireAnimDrivenInstaller());
            entity.GetFireCondition().Add(() => entity.GetHealth().IsNotEmpty);
            entity.GetFireCondition().Add(() => entity.GetWeapon().Value.GetFireCondition().Invoke());
            entity.GetFireAction().Add(() => entity.GetWeapon().Value.GetFireAction().Invoke());
            entity.GetFireAnimDrivenEvent().Subscribe(() => entity.GetWeapon().Value.GetFireEvent().Invoke()).AddTo(_disposableComposite);

            entity.AddBehaviour<CollisionAttackTargetBehaviour>();
            entity.AddBehaviour(new IncreaseScoreBehaviour(gameContext));

            entity.WhenDispose(_disposableComposite.Dispose);
        }
    }
}