using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField]
        private Const<GameEntity> _character;

        [SerializeField]
        private BulletPoolInstaller _bulletPoolInstaller;

        public override void Install(IGameContext context)
        {
            context.AddCharacter(_character);
            context.Install(_bulletPoolInstaller);
            context.AddScore(new ReactiveVariable<int>());
        }
    }
}
