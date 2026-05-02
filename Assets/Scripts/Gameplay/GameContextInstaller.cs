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
            // WorldBounds
            Container
                .Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();

            // Difficulty
            Container
                .Bind<IDifficulty>()
                .To<Difficulty>()
                .AsSingle()
                .WithArguments(_levelCount);

            Container
                .BindInterfacesTo<DifficultyController>()
                .AsSingle();

            // Score
            Container
                .Bind<IScore>()
                .To<Score>()
                .AsSingle();

            Container
                .BindInterfacesTo<ScoreController>()
                .AsSingle();

            // Coins
            Container
                .BindMemoryPoolCustomInterface<Coin, CoinPool, IMemoryPool<Vector2Int, Coin>>()
                .WithInitialSize(9)
                .FromComponentInNewPrefab(_coinPrefab)
                .UnderTransform(_coinContainer)
                .AsSingle();

            Container
                .Bind<CoinManager>()
                .AsSingle();

            Container
                .BindInterfacesTo<CoinConsumeController>()
                .AsSingle();

            Container
                .BindInterfacesTo<CoinSpawnController>()
                .AsSingle();

            // GameCycle
            Container
                .Bind<GameCycle>()
                .AsSingle();

            Container
                .BindInterfacesTo<DifficultyGameCycleController>()
                .AsSingle();

            Container
                .BindInterfacesTo<SnakeGameCycleController>()
                .AsSingle();
        }
    }
}