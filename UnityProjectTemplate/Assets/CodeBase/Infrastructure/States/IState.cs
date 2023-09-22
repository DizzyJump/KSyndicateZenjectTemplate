using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}