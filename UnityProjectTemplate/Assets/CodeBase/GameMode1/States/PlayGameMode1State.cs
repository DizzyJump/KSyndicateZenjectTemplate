using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.GameMode1.States
{
    public class PlayGameMode1State : IState
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