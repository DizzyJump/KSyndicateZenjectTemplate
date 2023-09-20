using CodeBase.GameLoading.States;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using UnityEngine;
using Zenject;

namespace CodeBase.GameLoading
{
    public class GameLoadingSceneBootstraper : IInitializable
    {
        private readonly SceneStateMachine sceneStateMachine;
        private readonly StatesFactory statesFactory;
        private readonly ILogService log;

        public GameLoadingSceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory, ILogService log)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.statesFactory = statesFactory;
            this.log = log;
        }

        public void Initialize()
        {
            log.Log("Start loading scene bootstraping");

            sceneStateMachine.RegisterState(statesFactory.Create<ServerConnectState>());
            sceneStateMachine.RegisterState(statesFactory.Create<LoadPlayerProgressState>());
            sceneStateMachine.RegisterState(statesFactory.Create<PrivatePolicyState>());
            sceneStateMachine.RegisterState(statesFactory.Create<GDPRState>());
            sceneStateMachine.RegisterState(statesFactory.Create<FinishGameLoadingState>());

            log.Log("Finish loading scene bootstraping");
            
            // go to the first scene state
            sceneStateMachine.Enter<ServerConnectState>();
        }
    }
}