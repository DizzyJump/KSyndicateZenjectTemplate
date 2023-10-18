using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.States
{
    public class PlayGameplayState : IState
    {
        public UniTask Enter()
        {
            // use such states for actual gameplay
            return default;
        }

        public UniTask Exit()
        {
            return default;
        }
    }
}