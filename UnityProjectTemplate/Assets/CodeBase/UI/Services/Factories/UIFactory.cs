using CodeBase.UI.PopUps.ErrorPopup;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        readonly PolicyAcceptPopup.Factory privatePolicyWindowFactory;
        private readonly ErrorPopup.Factory errorPopupFactory;

        public UIFactory(PolicyAcceptPopup.Factory privatePolicyWindowFactory, ErrorPopup.Factory errorPopupFactory)
        {
            this.privatePolicyWindowFactory = privatePolicyWindowFactory;
            this.errorPopupFactory = errorPopupFactory;
        }

        public UniTask<PolicyAcceptPopup> CreatePolicyAskingPopup() => privatePolicyWindowFactory.Create(UIFactoryAssets.PolicyAcceptPopup);

        public UniTask<ErrorPopup> CreateErrorPopup() => errorPopupFactory.Create(UIFactoryAssets.ErrorPopup);
        
        public void Cleanup()
        {
            
        }
    }
}