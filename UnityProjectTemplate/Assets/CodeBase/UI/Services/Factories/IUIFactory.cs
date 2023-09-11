using CodeBase.UI.PopUps.PolicyAcceptPopup;

namespace CodeBase.UI.Services.Factories
{
    public interface IUIFactory
    {
        
        void Cleanup();
        PolicyAcceptPopup CreatePrivatePolicyPopup();
    }
}