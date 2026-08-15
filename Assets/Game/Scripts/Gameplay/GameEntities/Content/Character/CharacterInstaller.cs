using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public class CharacterInstaller : SceneEntityInstaller<IGameEntity>
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
        private AimInstaller _aimInstaller;

        [SerializeField]
        private Const<GameEntity> _weapon;

        [SerializeField]
        private Cooldown _initialAimCooldown;

        [SerializeField]
        private TriggerEvents _trigger;

        [SerializeField]
        private AnimationEvents _animEvents;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();
            entity.Install(new TransformInstaller(_transform));
            entity.AddHealth(_health);
            entity.AddTrigger(_trigger);
            entity.AddAnimEvents(_animEvents);
            entity.AddBehaviour<TriggerInteractBehaviour>();

            entity.AddRotateSpeed(_rotateSpeed);
            entity.Install(_moveInstaller);
            entity.GetMoveCondition().Add(_ => entity.GetHealth().IsNotEmpty);
            entity.GetMoveAction().Add(entity.RotateStep);

            entity.WhenInit(() => entity.GetPostAimTimer().OnStarted += OnPostAimTimerStarted);
            entity.WhenDispose(() => entity.GetPostAimTimer().OnStarted -= OnPostAimTimerStarted);
            entity.WhenTick(deltaTime => _initialAimCooldown.Tick(deltaTime));

            entity.AddWeapon(_weapon);
            entity.Install(new FireAnimDrivenInstaller());
            entity.GetFireCondition().Add(() => entity.GetHealth().IsNotEmpty);
            entity.GetFireCondition().Add(() => entity.GetWeapon().Value.GetFireCondition().Invoke());
            entity.GetFireCondition().Add(() => _initialAimCooldown.IsCompleted());
            entity.GetFireAction().Add(() => entity.GetWeapon().Value.GetFireAction().Invoke());
            entity.GetFireAnimDrivenEvent().Subscribe(() => entity.GetWeapon().Value.GetFireEvent().Invoke()).AddTo(_disposableComposite);

            entity.Install(_aimInstaller);
            entity.GetAimCondition().Add(_ => entity.GetHealth().IsNotEmpty);
            entity.GetAimAction().Add(entity.RotateStep);
            entity.GetAimAction().Add((_, _) => entity.GetFireRequest().Invoke());

            entity.WhenDispose(_disposableComposite.Dispose);
        }

        private void OnPostAimTimerStarted()
        {
            _initialAimCooldown.ResetTime();
        }
    }
}