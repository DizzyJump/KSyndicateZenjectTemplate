using CodeBase.UI.Windows.PrivatePolicyAccept;

namespace CodeBase.UI.Factories
{
    public interface IUIFactory
    {
        
        void Cleanup();
        PolicyAcceptPopup CreatePrivatePolicyPopup();
    }
}