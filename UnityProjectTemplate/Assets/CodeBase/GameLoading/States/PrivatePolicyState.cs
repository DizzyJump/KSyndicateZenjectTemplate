using System.Threading.Tasks;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.PopUps;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class PrivatePolicyState : IState
    {
        private readonly IPopUpService popUpService;
        private readonly SceneStateMachine sceneStateMachine;
        private readonly IPersistentProgressService progressService;
        private readonly ILogService log;
        private readonly IStaticDataService staticData;

        public PrivatePolicyState(IPopUpService popUpService, IStaticDataService staticData, SceneStateMachine sceneStateMachine, IPersistentProgressService progressService, ILogService log)
        {
            this.popUpService = popUpService;
            this.sceneStateMachine = sceneStateMachine;
            this.progressService = progressService;
            this.log = log;
            this.staticData = staticData;
        }

        public async UniTask Enter()
        {
            log.Log("PrivatePolicyState enter");
            
            if (!progressService.Progress.PrivatePolicyAccepted) 
                await AskToAcceptPrivatePolicy();
            
            if (progressService.Progress.PrivatePolicyAccepted)
                sceneStateMachine.Enter<GDPRState>().Forget();
            else
                log.Log("Player cant play our game due to somehow reject private policy :)");
        }

        private async Task AskToAcceptPrivatePolicy()
        {
            var popupConfig = staticData.GetPolicyAcceptPopupConfig(PolicyAcceptPopupTypes.PrivatePolicy);
            
            bool result = await popUpService.AskPolicyPopup(popupConfig);
            
            progressService.Progress.PrivatePolicyAccepted = result;
        }

        public UniTask Exit() => default;
    }
}