using CodeBase.Services.AdsService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine gameStateMachine;
        private IAdsService adsService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IAdsService adsService)
        {
            Debug.Log("BootstrapState constructor");
            this.adsService = adsService;
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("BootstrapState Enter");
            adsService.Initialize();
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