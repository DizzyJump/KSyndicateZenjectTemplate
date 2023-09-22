using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}