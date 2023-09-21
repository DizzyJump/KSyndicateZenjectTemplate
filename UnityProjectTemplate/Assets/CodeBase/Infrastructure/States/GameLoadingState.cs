using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneProvider sceneProvider;
        private readonly IAssetProvider assetProvider;

        public GameLoadingState(ILoadingCurtain loadingCurtain, ISceneProvider sceneProvider, IAssetProvider assetProvider)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneProvider = sceneProvider;
            this.assetProvider = assetProvider;
        }

        public async void Enter()
        {
            loadingCurtain.Show();
            
            await assetProvider.WarmupAssetsByLabel(AssetLabels.GameLoadingState);
            await sceneProvider.Load(InfrastructureAssetPath.GameLoadingScene);
            
            loadingCurtain.Hide();
        }

        public async void Exit()
        {
            loadingCurtain.Show();
            
            await sceneProvider.Unload(InfrastructureAssetPath.GameLoadingScene);
            await assetProvider.ReleaseAssetsByLabel(AssetLabels.GameLoadingState);
        }
    }
}