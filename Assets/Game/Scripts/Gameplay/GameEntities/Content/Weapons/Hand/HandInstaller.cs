using Atomic.Elements;
using Atomic.Entities;
using System;
using UnityEngine;

namespace Game
{
    public sealed class HandInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Cooldown _cooldown;

        [SerializeField]
        private float _attackRadius = 0.2f;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private Const<int> _damage;

        public override void Install(IGameEntity entity)
        {
            entity.AddDamage(_damage);

            entity.AddFireCooldown(_cooldown);
            entity.WhenTick(deltaTime => entity.GetFireCooldown().Tick(deltaTime));

            entity.Install(new FireInstaller());
            entity.GetFireCondition().Add(() => entity.GetFireCooldown().IsCompleted());
            entity.GetFireAction().Add(() => entity.GetFireCooldown().ResetTime());
            entity.GetFireAction().Add(
                () => CombatProcedures.PerformSphereAttack(
                    transform.position,
                    _attackRadius,
                    _layerMask,
                    entity.GetDamage().Value
                )
            );
        }
    }
}