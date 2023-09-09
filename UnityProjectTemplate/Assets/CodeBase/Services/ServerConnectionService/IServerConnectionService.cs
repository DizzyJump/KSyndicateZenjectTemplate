using Cysharp.Threading.Tasks;

namespace CodeBase.Services.ServerConnectionService
{
    public interface IServerConnectionService
    {
        UniTask<ConnectionResult> Connect(ServerConnectionConfig config);
    }
}