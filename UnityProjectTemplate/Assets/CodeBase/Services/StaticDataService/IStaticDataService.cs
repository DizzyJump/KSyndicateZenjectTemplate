using CodeBase.Services.ServerConnectionService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        UniTask Initialize();
        ServerConnectionConfig ServerConnectionConfig { get; }
        PolicyAcceptPopupConfig GetPolicyAcceptPopupConfig(PolicyAcceptPopupTypes type);
    }
}