using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeContextInstaller : MonoInstaller
    {
        [SerializeField]
        private Snake _snake;

        public override void InstallBindings()
        {
            Container
                .Bind<ISnake>()
                .To<Snake>()
                .FromInstance(_snake)
                .AsSingle();

            Container
                .BindInterfacesTo<SnakeInputController>()
                .AsSingle()
                .NonLazy();
        }
    }
}