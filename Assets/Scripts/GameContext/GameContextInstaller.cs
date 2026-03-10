using Game;
using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameContextInstaller : MonoInstaller
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
                .BindInterfacesAndSelfTo<SnakeInputController>()
                .AsSingle()
                .NonLazy();
        }
    }
}