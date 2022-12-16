using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            Debug.Log("BootstrapState constructor");
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("BootstrapState Enter");
            gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState Exit");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}