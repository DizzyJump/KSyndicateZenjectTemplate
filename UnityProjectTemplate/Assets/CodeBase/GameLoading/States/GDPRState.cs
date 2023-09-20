using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.PopUps;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class GDPRState : IState
    {
        private readonly IPopUpService popUpService;
        private readonly PolicyAcceptPopupConfig gdprPolicyPopupConfig;
        private readonly SceneStateMachine sceneStateMachine;
        private readonly IPersistentProgressService progressService;
        private readonly ILogService log;

        public GDPRState(IPopUpService popUpService, PolicyAcceptPopupConfig gdprPolicyPopupConfig, SceneStateMachine sceneStateMachine, IPersistentProgressService progressService, ILogService log)
        {
            this.popUpService = popUpService;
            this.gdprPolicyPopupConfig = gdprPolicyPopupConfig;
            this.sceneStateMachine = sceneStateMachine;
            this.progressService = progressService;
            this.log = log;
        }

        public async void Enter()
        {
            log.Log("GDPRState enter");

            if(!progressService.Progress.GDPRPolicyAccepted)
                await AskToAcceptGDPRPolicy();
            
            if (progressService.Progress.GDPRPolicyAccepted)
                sceneStateMachine.Enter<FinishGameLoadingState>();
            else
                log.Log("Player cant play our game due to reject gdpr policy :)");
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