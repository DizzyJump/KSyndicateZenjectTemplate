using CodeBase.GameLoading.States;
using CodeBase.Infrastructure.GameLoading.States;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.GameLoading
{
    public class GameLoadingSceneBootstraper : IInitializable
    {
        private SceneStateMachine sceneStateMachine;
        private GameStateMachine gameStateMachine;
        private StatesFactory statesFactory;

        public GameLoadingSceneBootstraper(SceneStateMachine sceneStateMachine, GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.gameStateMachine = gameStateMachine;
            this.statesFactory = statesFactory;
        }

        public void Initialize()
        {
            Debug.Log("Start loading scene bootstraping");
            
            // due to scene loaded and scene context bindings done
            // we init global state for our scene to finish preparations on global app layer
            gameStateMachine.Enter<GameLoadingState>();

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