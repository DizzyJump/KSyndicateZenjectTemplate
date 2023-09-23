using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using CodeBase.Services.ServerConnectionService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Overlays;
using CodeBase.UI.Services.PopUps;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class ServerConnectState : IState
    {
        private readonly IServerConnectionService serverConnectionService;
        private readonly IStaticDataService staticDataService;
        private readonly SceneStateMachine sceneStateMachine;
        private readonly IAwaitingOverlay awaitingOverlay;
        private readonly IPopUpService popUpService;
        private readonly ILogService log;

        public ServerConnectState(IServerConnectionService serverConnectionService, IStaticDataService staticDataService, SceneStateMachine sceneStateMachine, IAwaitingOverlay awaitingOverlay, IPopUpService popUpService, ILogService log)
        {
            this.serverConnectionService = serverConnectionService;
            this.staticDataService = staticDataService;
            this.sceneStateMachine = sceneStateMachine;
            this.awaitingOverlay = awaitingOverlay;
            this.popUpService = popUpService;
            this.log = log;
        }

        public async UniTask Enter()
        {
            log.Log("ServerConnectState enter");
            awaitingOverlay.Show("Connection to server...");
            
            ConnectionResult result = await serverConnectionService.Connect(staticDataService.ServerConnectionConfig);
            
            awaitingOverlay.Hide();
            
            if(result == ConnectionResult.Success)
                sceneStateMachine.Enter<LoadPlayerProgressState>().Forget();
            else
            {
                // some works on connection error for example repeat
                await popUpService.ShowError("Connection error",
                    "Can't connect to server. Please check your internet connection.");
            }
        }

        public UniTask Exit() => default;
    }
}