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
        
        public void Initialize()
        {
            Debug.Log("Start loading scene bootstraping");
            
            // due to scene loaded and scene context bindings done we init global state for our scene to finish preparations on global app layer
            gameStateMachine.Enter<GameLoadingState>();
            
            sceneStateMachine.RegisterState(statesFactory.Create<PrivatePolicyState>());
            sceneStateMachine.RegisterState(statesFactory.Create<GDPRState>());
            sceneStateMachine.RegisterState(statesFactory.Create<ServerConnectState>());
            sceneStateMachine.RegisterState(statesFactory.Create<LoadPlayerProgressState>());
            
            Debug.Log("Finish loading scene bootstraping");
            
            sceneStateMachine.Enter<PrivatePolicyState>();
        }
    }
}