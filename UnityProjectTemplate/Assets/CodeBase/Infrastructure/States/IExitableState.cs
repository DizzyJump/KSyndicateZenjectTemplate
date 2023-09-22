using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}