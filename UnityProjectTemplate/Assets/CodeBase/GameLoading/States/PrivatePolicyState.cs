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

        public void Exit()
        {
            
        }

        public async void Enter()
        {
            if (!progressService.Progress.PrivatePolicyAccepted) 
                await AskToAcceptPrivatePolicy();
        }

        private async Task AskToAcceptPrivatePolicy()
        {
            bool result = await popUpService.AskPolicyPopup(privatePolicyPopupConfig);
            if (result)
                sceneStateMachine.Enter<GDPRState>();
            else
                Debug.Log("Player cant play our game due to reject private policy :)");
        }
    }
}