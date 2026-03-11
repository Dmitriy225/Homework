using Modules;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace SnakeGame
{
    public class GameContextInstaller : MonoInstaller
    {
        [SerializeField]
        private WorldBounds _worldBounds;

        public override void InstallBindings()
        {
            Container
                .Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromInstance(_worldBounds)
                .AsSingle();
        }
    }
}