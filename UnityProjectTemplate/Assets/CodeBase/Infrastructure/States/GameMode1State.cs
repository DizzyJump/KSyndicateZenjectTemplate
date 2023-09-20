using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameMode1State : IState
    {
        private readonly ILoadingCurtain loadingCurtain;
        private readonly ISceneLoader sceneLoader;
        private readonly ILogService log;

        public GameMode1State(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, ILogService log)
        {
            this.loadingCurtain = loadingCurtain;
            this.sceneLoader = sceneLoader;
            this.log = log;
        }

        public async void Enter()
        {
            log.Log("Game mode 1 state enter");
            loadingCurtain.Show();
            await sceneLoader.Load(InfrastructureAssetPath.GameMode1Scene);
            loadingCurtain.Hide();
        }

        public void Exit()
        {
            
        }
    }
}