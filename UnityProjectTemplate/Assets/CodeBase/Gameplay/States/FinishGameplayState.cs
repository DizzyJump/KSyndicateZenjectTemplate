using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.States
{
    public class FinishGameplayState : IState
    {
        private readonly GameStateMachine gameStateMachine;

        public FinishGameplayState(GameStateMachine gameStateMachine) => 
            this.gameStateMachine = gameStateMachine;

        public async UniTask Exit()
        {
            // use such states for finishing gameplay and cleanup resources, posting session statistics and leaving Game State
            gameStateMachine.Enter<GameHubState>().Forget();
        }

        public UniTask Enter()
        {
            return default;
        }
    }
}