using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.GameMode1.States
{
    public class WinGameMode1State : IState
    {
        public UniTask Exit()
        {
            // use such states for showing congratulation screens and offering bonuses for ads :)
            return default;
        }

        public UniTask Enter()
        {
            return default;
        }
    }
}