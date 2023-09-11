using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.PopUps;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class GDPRState : IState
    {
        private IPopUpService popUpService;
        private PolicyAcceptPopupConfig gdprPolicyPopupConfig;
        private SceneStateMachine sceneStateMachine;
        private IPersistentProgressService progressService;

        public GDPRState(IPopUpService popUpService, PolicyAcceptPopupConfig gdprPolicyPopupConfig, SceneStateMachine sceneStateMachine, IPersistentProgressService progressService)
        {
            this.popUpService = popUpService;
            this.gdprPolicyPopupConfig = gdprPolicyPopupConfig;
            this.sceneStateMachine = sceneStateMachine;
            this.progressService = progressService;
        }

        public async void Enter()
        {
            Debug.Log("GDPRState enter");

            if(!progressService.Progress.GDPRPolicyAccepted)
                await AskToAcceptGDPRPolicy();
            
            if (progressService.Progress.GDPRPolicyAccepted)
                sceneStateMachine.Enter<FinishGameLoadingState>();
            else
                Debug.Log("Player cant play our game due to reject gdpr policy :)");
        }

        private async Task AskToAcceptGDPRPolicy()
        {
            bool result = await popUpService.AskPolicyPopup(gdprPolicyPopupConfig);

            progressService.Progress.GDPRPolicyAccepted = result;
        }

        public void Exit()
        {
            
        }
    }
}