using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameHubState : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneLoader sceneLoader;
        private readonly ILogService log;

        public GameHubState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, ILogService log)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneLoader = sceneLoader;
            this.log = log;
        }

        public async void Enter()
        {
            log.Log("GameHub state exter");
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