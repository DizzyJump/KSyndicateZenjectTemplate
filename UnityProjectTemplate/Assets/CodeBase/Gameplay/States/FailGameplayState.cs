using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.States
{
    public class FailGameplayState : IState
    {
        public UniTask Enter()
        {
            // use such states for showing fail screens and offering resurrections and so on
            return default;
        }

        public UniTask Exit()
        {
            return default;
        }
    }
}