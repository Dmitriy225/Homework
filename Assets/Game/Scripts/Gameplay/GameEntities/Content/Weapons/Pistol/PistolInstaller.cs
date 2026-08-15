using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class PistolInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private Cooldown _cooldown;

        [SerializeField]
        private ReactiveVariable<int> _ammo;

        [SerializeField]
        private GameEntity _bulletPrefab;

        [SerializeField]
        private Const<float> _fireSpread = 0.25f;

        public override void Install(IGameEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.Install(new TransformInstaller(transform));

            entity.AddFirePosition(new InlineValue<Vector3>(() => _firePoint.position));
            entity.AddBulletPrefab(new Variable<GameEntity>(_bulletPrefab));
            entity.AddFireSpread(_fireSpread);
            entity.AddAmmo(_ammo);
            entity.AddFireCooldown(_cooldown);
            entity.WhenTick(deltaTime => entity.GetFireCooldown().Tick(deltaTime));

            entity.Install(new FireInstaller());
            entity.GetFireCondition().Add(() => entity.GetAmmo().Value > 0);
            entity.GetFireCondition().Add(() => entity.GetFireCooldown().IsCompleted());
            entity.GetFireAction().Add(() => entity.GetAmmo().Value--);
            entity.GetFireAction().Add(() => entity.GetFireCooldown().ResetTime());
            entity.GetFireAction().Add(() => entity.PerformBulletFire(gameContext));
        }
    }
}