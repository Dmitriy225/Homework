using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class BulletInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Const<float> _moveSpeed;

        [SerializeField]
        private Cooldown _lifeCooldown;

        [SerializeField]
        private Const<int> _damage;

        private GameEntity _entity;
        private IGameContext _gameContext;

        public override void Install(IGameEntity entity)
        {
            _entity = (GameEntity)entity;
            _gameContext = GameContext.Instance;

            entity.Install(new TransformInstaller(transform));

            entity.AddMoveSpeed(_moveSpeed);
            entity.WhenTick(deltaTime => entity.MoveStep(entity.GetRotation().Value * Vector3.forward, deltaTime));

            entity.AddDamage(_damage);

            entity.WhenInit(() => _lifeCooldown.OnCompleted += OnLifeCooldownCompleted);
            entity.WhenEnable(() => _lifeCooldown.ResetTime());
            entity.WhenDispose(() => _lifeCooldown.OnCompleted -= OnLifeCooldownCompleted);
            entity.WhenTick(deltaTime => _lifeCooldown.Tick(deltaTime));
        }

        private void OnLifeCooldownCompleted()
        {
            BulletProcedures.Return(_gameContext, _entity);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TakeDamage(_entity))
            {
                BulletProcedures.Return(_gameContext, _entity);
            }
        }
    }
}