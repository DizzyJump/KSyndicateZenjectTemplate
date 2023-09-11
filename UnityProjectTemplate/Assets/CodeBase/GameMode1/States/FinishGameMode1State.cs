using CodeBase.Infrastructure.States;

namespace CodeBase.GameMode1.States
{
    public class FinishGameMode1State : IState
    {
        private GameStateMachine gameStateMachine;

        public FinishGameMode1State(GameStateMachine gameStateMachine) => 
            this.gameStateMachine = gameStateMachine;

        public void Exit()
        {
            // use such states for finishing gameplay and cleanup resources, posting session statistics and leaving Game State
            gameStateMachine.Enter<GameHubState>();
        }

        public void Enter()
        {
            
        }
    }
}