using CodeBase.UI.PopUps.ErrorPopup;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.Factories
{
    public interface IUIFactory
    {
        
        void Cleanup();
        UniTask<PolicyAcceptPopup> CreatePolicyAskingPopup();
        UniTask<ErrorPopup> CreateErrorPopup();
    }
}