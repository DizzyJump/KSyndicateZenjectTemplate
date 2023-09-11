using CodeBase.GameLoading.States;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.GameLoading
{
    public class GameLoadingSceneBootstraper : IInitializable
    {
        private SceneStateMachine sceneStateMachine;
        private StatesFactory statesFactory;

        public GameLoadingSceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.statesFactory = statesFactory;
        }

        public void Initialize()
        {
            Debug.Log("Start loading scene bootstraping");

            sceneStateMachine.RegisterState(statesFactory.Create<ServerConnectState>());
            sceneStateMachine.RegisterState(statesFactory.Create<LoadPlayerProgressState>());
            sceneStateMachine.RegisterState(statesFactory.Create<PrivatePolicyState>());
            sceneStateMachine.RegisterState(statesFactory.Create<GDPRState>());
            sceneStateMachine.RegisterState(statesFactory.Create<FinishGameLoadingState>());

            Debug.Log("Finish loading scene bootstraping");
            
            // go to the first scene state
            sceneStateMachine.Enter<ServerConnectState>();
        }
    }
}