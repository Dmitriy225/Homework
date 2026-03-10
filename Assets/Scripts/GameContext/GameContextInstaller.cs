using Game;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameContextInstaller : MonoInstaller
    {
        [SerializeField]
        private Snake _snake;

        [SerializeField]
        private GameUI _gameUI;

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

            Container
                .Bind<IGameUI>()
                .To<GameUI>()
                .FromInstance(_gameUI)
                .AsSingle();

            Container
                .BindInterfacesTo<DefeatPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}