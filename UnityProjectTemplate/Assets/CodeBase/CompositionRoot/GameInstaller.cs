using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services.AdsService;
using CodeBase.Services.InputService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.RandomizerService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindLoadingCurtain();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();
        
            BindUIFactory();

            BindRandomizeService();

            BindPlayerProgressService();

            BindSaveLoadService();

            BindAdsService();

            BindInputService();
        }

        private void BindStaticDataService() => 
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstraper);
        }

        private void BindInputService() => 
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

        private void BindAdsService() => 
            Container.BindInterfacesAndSelfTo<AdsService>().AsSingle();

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

        private void BindRandomizeService() => 
            Container.BindInterfacesAndSelfTo<RandomizerService>().AsSingle();

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

        private void BindSceneLoader() => 
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindLoadingCurtain() => 
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().FromComponentInNewPrefabResource(InfrastructureAssetPath.CurtainPath).AsSingle();

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
}