using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class FinishGameLoadingState : IState
    {
        private GameStateMachine gameStateMachine;

        public FinishGameLoadingState(GameStateMachine gameStateMachine) => 
            this.gameStateMachine = gameStateMachine;

        public void Enter()
        {
            Debug.Log("FinishGameLoadingState enter");
            
            gameStateMachine.Enter<GameHubState>();
        }

        public void Exit()
        {
            
        }
    }
}