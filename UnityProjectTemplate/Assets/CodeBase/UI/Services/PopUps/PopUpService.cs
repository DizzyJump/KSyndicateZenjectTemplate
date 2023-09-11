using CodeBase.UI.PopUps.ErrorPopup;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using CodeBase.UI.Services.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Services.PopUps
{
    public class PopUpService : IPopUpService
    {
        private IUIFactory uiFactory;
        private ErrorPopup errorPopup;
        
        private ErrorPopupConfig errorPopupConfig;
        
        public PopUpService(IUIFactory uiFactory, ErrorPopup errorPopup)
        {
            this.uiFactory = uiFactory;
            this.errorPopup = errorPopup;
            errorPopupConfig = new ErrorPopupConfig();
        }

        public async UniTask<bool> AskPolicyPopup(PolicyAcceptPopupConfig config)
        {
            var popup = uiFactory.CreatePrivatePolicyPopup();
            bool result = await popup.Show(config);
            Object.Destroy(popup);
            return result;
        }

        public async UniTask ShowError(string messageHeader, string messageBody, string buttonText = "OK")
        {
            errorPopupConfig.HeaderText = messageHeader;
            errorPopupConfig.MessageText = messageBody;
            errorPopupConfig.ButtonText = buttonText;
            
            await errorPopup.Show(errorPopupConfig);
            errorPopup.Hide();
        }
    }
}