using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class TriggerZoneInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private GameEntity[] _entities;

        [SerializeField]
        private TriggerEvents _trigger;

        private IGameEntity _entity;
        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IGameEntity entity)
        {
            _entity = entity;

            entity.AddTarget(new ReactiveVariable<IGameEntity>());
            entity.GetTarget().Subscribe(OnTargetChanged).AddTo(_disposableComposite);

            entity.WhenInit(() => _trigger.OnEntered += OnTriggerEntered);
            entity.WhenDispose(() => _trigger.OnEntered -= OnTriggerEntered);

            entity.WhenInit(() => _trigger.OnExited += OnTriggerExited);
            entity.WhenDispose(() => _trigger.OnExited -= OnTriggerExited);

            entity.WhenDispose(_disposableComposite.Dispose);
        }

        private void OnTriggerEntered(Collider collider)
        {
            _entity.AssignCharacterTarget(collider);
        }

        private void OnTriggerExited(Collider collider)
        {
            _entity.RemoveTarget(collider);
        }

        private void OnTargetChanged(IGameEntity target)
        {
            foreach (var entity in _entities)
            {
                entity.AssignTarget(target);
            }
        }
    }
}