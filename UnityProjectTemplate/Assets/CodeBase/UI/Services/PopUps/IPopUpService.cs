using CodeBase.UI.Windows.PrivatePolicyAccept;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.PopUps
{
    public interface IPopUpService
    {
        UniTask<bool> AskPolicyPopup(PolicyAcceptPopupConfig config);
        UniTask ShowError(string messageHeader, string messageBody, string buttonText = "OK");
    }
}