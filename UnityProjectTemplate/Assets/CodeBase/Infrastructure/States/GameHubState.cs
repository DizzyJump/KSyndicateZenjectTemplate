using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameHubState : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneProvider sceneProvider;
        private readonly ILogService log;
        private readonly IAssetProvider assetProvider;

        public GameHubState(ILoadingCurtain loadingCurtain, ISceneProvider sceneProvider, ILogService log, IAssetProvider assetProvider)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneProvider = sceneProvider;
            this.log = log;
            this.assetProvider = assetProvider;
        }

        public async void Enter()
        {
            log.Log("GameHub state exter");
            loadingCurtain.Show();

            await assetProvider.WarmupAssetsByLabel(AssetLabels.GameHubState);
            // due to we don't have any substates for this state jet we just load scene with game hub decorations
            await sceneProvider.Load(InfrastructureAssetPath.GameHubScene);
            
            loadingCurtain.Hide();
        }

        public async void Exit()
        {
            loadingCurtain.Show();
            await sceneProvider.Unload(InfrastructureAssetPath.GameHubScene);
            await assetProvider.ReleaseAssetsByLabel(AssetLabels.GameHubState);
        }
    }
}