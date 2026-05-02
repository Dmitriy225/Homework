using Game;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeInstaller : MonoInstaller
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
                .BindInterfacesTo<SnakeExpandController>()
                .AsSingle();

            Container
                .BindInterfacesTo<SnakeInputController>()
                .AsSingle();

            Container
                .BindInterfacesTo<SnakeStopController>()
                .AsSingle();
        }
    }
}