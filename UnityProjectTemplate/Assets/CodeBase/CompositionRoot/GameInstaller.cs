using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.States;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.AdsService;
using CodeBase.Services.AnalyticsService;
using CodeBase.Services.InputService;
using CodeBase.Services.LocalizationService;
using CodeBase.Services.LogService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.RandomizerService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.ServerConnectionService;
using CodeBase.Services.StaticDataService;
using CodeBase.Services.WalletService;
using CodeBase.UI.Overlays;
using CodeBase.UI.Services.Factories;
using Cysharp.Threading.Tasks;
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

            BindInfrastructureUI();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();

            BindRandomizeService();

            BindPlayerProgressService();

            BindSaveLoadService();

            BindAdsService();

            BindInputService();

            BindAnalyticsService();

            BindServerConnectionService();

            BindLocalizationService();

            BindLogService();

            BindAssetProvider();

            BindWalletService();
        }

        private void BindWalletService() => 
            Container.BindInterfacesAndSelfTo<WalletService>().AsSingle();

        private void BindAssetProvider() => 
            Container.BindInterfacesTo<AssetProvider>().AsSingle();

        private void BindLogService() => 
            Container.BindInterfacesTo<LogService>().AsSingle();

        private void BindLocalizationService() => 
            Container.BindInterfacesTo<LocalizationService>().AsSingle();

        private void BindServerConnectionService() => 
            Container.BindInterfacesTo<ServerConnectionService>().AsSingle();

        private void BindAnalyticsService() => 
            Container.BindInterfacesTo<AnalyticsService>().AsSingle();

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
                .BindInterfacesAndSelfTo<PersistentProgressService>()
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

        private void BindInfrastructureUI()
        {
            BindLoadingCurtains();

            BindAwaitingOverlay();
        }

        private void BindAwaitingOverlay()
        {
            Container
                .BindFactory<string, UniTask<AwaitingOverlay>, AwaitingOverlay.Factory>()
                .FromFactory<PrefabFactoryAsync<AwaitingOverlay>>();

            Container.BindInterfacesAndSelfTo<AwaitingOverlayProxy>().AsSingle();
        }

        private void BindLoadingCurtains()
        {
            Container.BindFactory<string, UniTask<LoadingCurtain>, LoadingCurtain.Factory>()
                .FromFactory<PrefabFactoryAsync<LoadingCurtain>>();

            Container.BindInterfacesAndSelfTo<LoadingCurtainProxy>().AsSingle();
        }

        private void BindGameStateMachine() => 
            GameStateMachineInstaller.Install(Container);
    }
}