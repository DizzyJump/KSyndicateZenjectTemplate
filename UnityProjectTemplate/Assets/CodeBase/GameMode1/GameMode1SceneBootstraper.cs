using CodeBase.GameLoading.States;
using CodeBase.GameMode1.States;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.GameMode1
{
    public class GameMode1SceneBootstraper : IInitializable
    {
        private SceneStateMachine sceneStateMachine;
        private StatesFactory statesFactory;

        public GameMode1SceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.statesFactory = statesFactory;
        }

        public void Initialize()
        {
            Debug.Log("Start game mode scene bootstraping");

            sceneStateMachine.RegisterState(statesFactory.Create<StartGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<PlayGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<WinGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<FailGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<FinishGameMode1State>());

            Debug.Log("Finish game mode scene bootstraping");
            
            // go to the first scene state
            sceneStateMachine.Enter<StartGameMode1State>();
        }
    }
}