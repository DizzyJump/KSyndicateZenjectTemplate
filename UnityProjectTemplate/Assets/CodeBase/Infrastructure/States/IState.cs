namespace CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}