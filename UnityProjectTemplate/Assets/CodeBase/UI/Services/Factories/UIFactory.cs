using CodeBase.UI.Windows.PrivatePolicyAccept;

namespace CodeBase.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        PolicyAcceptPopup.Factory privatePolicyWindowFactory;

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