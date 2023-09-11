using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.PopUps
{
    public interface IPopUpService
    {
        UniTask<bool> AskPolicyPopup(PolicyAcceptPopupConfig config);
        UniTask ShowError(string messageHeader, string messageBody, string buttonText = "OK");
    }
}