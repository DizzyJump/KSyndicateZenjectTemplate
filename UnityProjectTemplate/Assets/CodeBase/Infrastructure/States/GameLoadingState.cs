using System.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneLoader sceneLoader;

        public GameLoadingState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneLoader = sceneLoader;
        }

        public void Exit()
        {
            loadingCurtain.Show();
        }

        public async void Enter()
        {
            loadingCurtain.Show();
            await sceneLoader.Load(InfrastructureAssetPath.GameLoadingScene);
            loadingCurtain.Hide();
        }
    }
}