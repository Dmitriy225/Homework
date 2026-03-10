using Modules;
using System;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Game
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