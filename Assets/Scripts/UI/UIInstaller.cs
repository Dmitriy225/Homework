using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private GameUI _gameUI;

        public override void InstallBindings()
        {
            Container
                .Bind<IGameUI>()
                .To<GameUI>()
                .FromInstance(_gameUI)
                .AsSingle();

            Container
                .BindInterfacesTo<ScorePresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<LevelPresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<GameOverPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}