using System;
using System.Threading;
using CodeBase.UI.PopUps.ErrorPopup;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.Factories;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Services.PopUps
{
    public class PopUpService : IPopUpService, IDisposable
    {
        private readonly IUIFactory uiFactory;
        private readonly ErrorPopup errorPopup;
        
        private readonly ErrorPopupConfig errorPopupConfig;

        private CancellationTokenSource ctn;
        
        public PopUpService(IUIFactory uiFactory, ErrorPopup errorPopup)
        {
            this.uiFactory = uiFactory;
            this.errorPopup = errorPopup;
            errorPopupConfig = new ErrorPopupConfig();
            ctn = new CancellationTokenSource();
        }

        public async UniTask<bool> AskPolicyPopup(PolicyAcceptPopupConfig config)
        {
            var popup = await uiFactory.CreatePolicyAskingPopup();
            bool result = await popup.Show(config).AttachExternalCancellation(ctn.Token);
            Object.Destroy(popup);
            return result;
        }

        public async UniTask ShowError(string messageHeader, string messageBody, string buttonText = "OK")
        {
            errorPopupConfig.HeaderText = messageHeader;
            errorPopupConfig.MessageText = messageBody;
            errorPopupConfig.ButtonText = buttonText;
            
            await errorPopup.Show(errorPopupConfig).AttachExternalCancellation(ctn.Token);
            errorPopup.Hide();
        }

        public void Dispose() => 
            ctn.Cancel();
    }
}