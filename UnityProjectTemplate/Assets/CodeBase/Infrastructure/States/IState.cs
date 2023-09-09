using System.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}