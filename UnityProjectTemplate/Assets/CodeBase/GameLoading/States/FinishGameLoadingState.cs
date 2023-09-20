using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class FinishGameLoadingState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly ILogService log;

        public FinishGameLoadingState(GameStateMachine gameStateMachine, ILogService log)
        {
            this.gameStateMachine = gameStateMachine;
            this.log = log;
        }

        public void Enter()
        {
            log.Log("FinishGameLoadingState enter");
            
            gameStateMachine.Enter<GameHubState>();
        }

        public void Exit()
        {
            
        }
    }
}