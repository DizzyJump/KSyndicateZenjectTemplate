using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.UI.Services.PopUps;
using CodeBase.UI.Windows.PrivatePolicyAccept;
using UnityEngine;

namespace CodeBase.Infrastructure.GameLoading.States
{
    public class PrivatePolicyState : IState
    {
        private IPopUpService popUpService;
        private PolicyAcceptPopupConfig privatePolicyPopupConfig;
        private SceneStateMachine sceneStateMachine;
        private IPersistentProgressService progressService;

        public PrivatePolicyState(IPopUpService popUpService, PolicyAcceptPopupConfig privatePolicyPopupConfig, SceneStateMachine sceneStateMachine, IPersistentProgressService progressService)
        {
            this.popUpService = popUpService;
            this.privatePolicyPopupConfig = privatePolicyPopupConfig;
            this.sceneStateMachine = sceneStateMachine;
            this.progressService = progressService;
        }

        public async void Enter()
        {
            Debug.Log("PrivatePolicyState enter");
            
            if (!progressService.Progress.PrivatePolicyAccepted) 
                await AskToAcceptPrivatePolicy();
            
            if (progressService.Progress.PrivatePolicyAccepted)
                sceneStateMachine.Enter<GDPRState>();
            else
                Debug.Log("Player cant play our game due to somehow reject private policy :)");
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