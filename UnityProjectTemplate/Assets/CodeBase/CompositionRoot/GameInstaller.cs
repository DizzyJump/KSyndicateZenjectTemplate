using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.Randomizer;
using CodeBase.Services.SaveLoadService;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindCoroutineRunner();

        BindSceneLoader();

        BindLoadingCurtain();

        BindGameStateMachine();

        BindGameFactory();
        
        BindUIFactory();

        BindRandomizeService();

        BindPlayerProgressService();

        BindSaveLoadService();
    }

    private void BindSaveLoadService()
    {
        Container
            .BindInterfacesAndSelfTo<SaveLoadService>()
            .AsSingle();
    }

    private void BindPlayerProgressService()
    {
        Container
            .BindInterfacesAndSelfTo<PlayerProgressService>()
            .AsSingle();
    }

    private void BindRandomizeService()
    {
        Container.BindInterfacesAndSelfTo<RandomizerService>().AsSingle();
    }

    private void BindGameFactory()
    {
        Container
            .Bind<IGameFactory>()
            .FromSubContainerResolve()
            .ByInstaller<GameFactoryInstaller>()
            .AsSingle();
    }

    private void BindUIFactory()
    {
        Container
            .Bind<IUIFactory>()
            .FromSubContainerResolve()
            .ByInstaller<UIFactoryInstaller>()
            .AsSingle();
    }

    private void BindCoroutineRunner()
    {
        Container
            .Bind<ICoroutineRunner>()
            .To<CoroutineRunner>()
            .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
    }

    private void BindLoadingCurtain()
    {
        Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().FromComponentInNewPrefabResource(InfrastructureAssetPath.CurtainPath).AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container
            .Bind<IGameStateMachine>()
            .FromSubContainerResolve()
            .ByInstaller<GameStateMachineInstaller>()
            .AsSingle();
        Debug.Log("Bind IGameStateMachine");
    }
}