using Atomic.Entities;
using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class AmmoItemInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private int _ammo = 10;

        public override void Install(IGameEntity entity)
        {
            entity.Install(new InteractInstaller());
            entity.GetInteractCondition().Add(character => character.HasCharacterTag());
            entity.GetInteractAction().Add(
                character =>
                {
                    if (character.CollectAmmo(_ammo))
                    {
                        SceneEntity.Destroy((GameEntity)entity);
                    }
                }
            );
        }
    }
}