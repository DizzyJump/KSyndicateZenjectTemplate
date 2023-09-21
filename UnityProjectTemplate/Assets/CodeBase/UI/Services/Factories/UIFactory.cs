using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        readonly PolicyAcceptPopup.Factory privatePolicyWindowFactory;

        public UIFactory(PolicyAcceptPopup.Factory privatePolicyWindowFactory)
        {
            this.privatePolicyWindowFactory = privatePolicyWindowFactory;
        }

        public UniTask<PolicyAcceptPopup> CreatePolicyAskingPopup() => privatePolicyWindowFactory.Create(UIFactoryAssets.PolicyAcceptPopup);
        
        public void Cleanup()
        {
            
        }
    }
}