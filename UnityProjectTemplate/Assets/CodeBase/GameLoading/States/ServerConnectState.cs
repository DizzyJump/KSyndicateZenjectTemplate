using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.ServerConnectionService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Factories;
using CodeBase.UI.Overlays;
using CodeBase.UI.Services.PopUps;

namespace CodeBase.Infrastructure.GameLoading.States
{
    public class ServerConnectState : IState
    {
        private IServerConnectionService serverConnectionService;
        private IStaticDataService staticDataService;
        private SceneStateMachine sceneStateMachine;
        private AwaitingOverlay awaitingOverlay;
        private IPopUpService popUpService;

        public ServerConnectState(IServerConnectionService serverConnectionService, IStaticDataService staticDataService, SceneStateMachine sceneStateMachine, AwaitingOverlay awaitingOverlay, IPopUpService popUpService)
        {
            this.serverConnectionService = serverConnectionService;
            this.staticDataService = staticDataService;
            this.sceneStateMachine = sceneStateMachine;
            this.awaitingOverlay = awaitingOverlay;
            this.popUpService = popUpService;
        }

        public async void Enter()
        {
            awaitingOverlay.Show("Connection to server...");
            ConnectionResult result = await serverConnectionService.Connect(staticDataService.ServerConnectionConfig);
            awaitingOverlay.Hide();
            if(result == ConnectionResult.Success)
                sceneStateMachine.Enter<LoadPlayerProgressState>();
            else
            {
                // some works on connection error for example repeat
                await popUpService.ShowError("Connection error",
                    "Can't connect to server. Please check your internet connection.");
            }
        }

        public void Exit()
        {
            
        }
    }
}