using CodeBase.UI.PopUps.PolicyAcceptPopup;

namespace CodeBase.UI.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        readonly PolicyAcceptPopup.Factory privatePolicyWindowFactory;

        public UIFactory(PolicyAcceptPopup.Factory privatePolicyWindowFactory)
        {
            this.privatePolicyWindowFactory = privatePolicyWindowFactory;
        }

        public PolicyAcceptPopup CreatePrivatePolicyPopup() => privatePolicyWindowFactory.Create();
        
        public void Cleanup()
        {
            
        }
    }
}