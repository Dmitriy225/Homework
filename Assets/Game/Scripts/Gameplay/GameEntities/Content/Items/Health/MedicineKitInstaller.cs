using Atomic.Entities;
using Atomic.Elements;
using System;
using UnityEngine;

namespace Game
{
    public sealed class MedicineKitInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private int _hitPoints = 3;

        public override void Install(IGameEntity entity)
        {
            entity.Install(new InteractInstaller());
            entity.GetInteractCondition().Add(character => character.HasCharacterTag());
            entity.GetInteractAction().Add(
                character =>
                {
                    if (character.Heal(_hitPoints))
                    {
                        SceneEntity.Destroy((GameEntity)entity);
                    }
                }
            );
        }
    }
}