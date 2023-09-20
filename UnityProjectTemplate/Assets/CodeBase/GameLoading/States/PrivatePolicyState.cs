using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.PopUps;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class PrivatePolicyState : IState
    {
        private readonly IPopUpService popUpService;
        private readonly PolicyAcceptPopupConfig privatePolicyPopupConfig;
        private readonly SceneStateMachine sceneStateMachine;
        private readonly IPersistentProgressService progressService;
        private readonly ILogService log;

        public PrivatePolicyState(IPopUpService popUpService, PolicyAcceptPopupConfig privatePolicyPopupConfig, SceneStateMachine sceneStateMachine, IPersistentProgressService progressService, ILogService log)
        {
            this.popUpService = popUpService;
            this.privatePolicyPopupConfig = privatePolicyPopupConfig;
            this.sceneStateMachine = sceneStateMachine;
            this.progressService = progressService;
            this.log = log;
        }

        public async void Enter()
        {
            log.Log("PrivatePolicyState enter");
            
            if (!progressService.Progress.PrivatePolicyAccepted) 
                await AskToAcceptPrivatePolicy();
            
            if (progressService.Progress.PrivatePolicyAccepted)
                sceneStateMachine.Enter<GDPRState>();
            else
                log.Log("Player cant play our game due to somehow reject private policy :)");
        }

        private async Task AskToAcceptPrivatePolicy()
        {
            bool result = await popUpService.AskPolicyPopup(privatePolicyPopupConfig);
            
            progressService.Progress.PrivatePolicyAccepted = result;
        }

        public void Exit()
        {
            
        }
    }
}