using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameMode1State : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneLoader sceneLoader;
        private readonly ILogService log;
        private readonly IAssetProvider assetProvider;

        public GameMode1State(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, ILogService log, IAssetProvider assetProvider)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneLoader = sceneLoader;
            this.log = log;
            this.assetProvider = assetProvider;
        }

        public async void Enter()
        {
            log.Log("Game mode 1 state enter");
            loadingCurtain.Show();
            await assetProvider.WarmupAssetsByLabel(AssetLabels.GameplayState);
            await sceneLoader.Load(InfrastructureAssetPath.GameMode1Scene);
            loadingCurtain.Hide();
        }

        public async void Exit()
        {
            loadingCurtain.Show();
            await assetProvider.ReleaseAssetsByLabel(AssetLabels.GameplayState);
        }
    }
}