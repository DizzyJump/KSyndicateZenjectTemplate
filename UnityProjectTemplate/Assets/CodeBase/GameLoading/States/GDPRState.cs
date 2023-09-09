using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.UI.Services.PopUps;
using CodeBase.UI.Windows.PrivatePolicyAccept;
using UnityEngine;

namespace CodeBase.Infrastructure.GameLoading.States
{
    public class GDPRState : IState
    {
        private IPopUpService popUpService;
        private PolicyAcceptPopupConfig gdprPolicyPopupConfig;
        private SceneStateMachine sceneStateMachine;

        public GDPRState(IPopUpService popUpService, PolicyAcceptPopupConfig gdprPolicyPopupConfig, SceneStateMachine sceneStateMachine)
        {
            this.popUpService = popUpService;
            this.gdprPolicyPopupConfig = gdprPolicyPopupConfig;
            this.sceneStateMachine = sceneStateMachine;
        }

        public async void Enter()
        {
            bool result = await popUpService.AskPolicyPopup(gdprPolicyPopupConfig);
            if(result)
                sceneStateMachine.Enter<ServerConnectState>();
            else
                Debug.Log("Player cant play our game due to reject gdpr policy :)");
        }

        public void Exit()
        {
            
        }
    }
}