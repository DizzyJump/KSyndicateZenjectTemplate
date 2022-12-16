using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
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
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
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