using Modules;
using UnityEngine;
using Zenject;

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


    }
}