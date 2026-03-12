using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class GameContextInstaller : MonoInstaller
    {
        [SerializeField]
        private WorldBounds _worldBounds;

        [SerializeField]
        private int _levelCount;

        [SerializeField]
        private Coin _coinPrefab;

        [SerializeField]
        private Transform _coinContainer;

        public override void InstallBindings()
        {
            Container
                .Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();

            Container
                .Bind<IDifficulty>()
                .To<Difficulty>()
                .AsSingle()
                .WithArguments(_levelCount);

            Container
                .BindMemoryPoolCustomInterface<Coin, CoinPool, IMemoryPool<Vector2Int, Coin>>()
                .WithInitialSize(9)
                .FromComponentInNewPrefab(_coinPrefab)
                .UnderTransform(_coinContainer)
                .AsSingle();

            Container
                .BindInterfacesTo<LevelManager>()
                .AsSingle();
        }
    }
}