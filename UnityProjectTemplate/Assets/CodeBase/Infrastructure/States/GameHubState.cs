using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameHubState : IState
    {
        private ILoadingCurtain loadingCurtain;
        private ISceneLoader sceneLoader;

        public GameHubState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            Debug.Log("GameHub state exter");
            loadingCurtain.Show();
            // due to we don't have any substates for this state jet we just load scene with game hub decorations
            await sceneLoader.Load(InfrastructureAssetPath.GameHubScene);
            loadingCurtain.Hide();
        }

        public void Exit()
        {
            
        }
    }
}