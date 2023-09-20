using CodeBase.GameLoading.States;
using CodeBase.GameMode1.States;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using UnityEngine;
using Zenject;

namespace CodeBase.GameMode1
{
    public class GameMode1SceneBootstraper : IInitializable
    {
        private readonly SceneStateMachine sceneStateMachine;
        private readonly StatesFactory statesFactory;
        private readonly ILogService log;

        public GameMode1SceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory, ILogService log)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.statesFactory = statesFactory;
            this.log = log;
        }

        public void Initialize()
        {
            log.Log("Start game mode scene bootstraping");

            sceneStateMachine.RegisterState(statesFactory.Create<StartGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<PlayGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<WinGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<FailGameMode1State>());
            sceneStateMachine.RegisterState(statesFactory.Create<FinishGameMode1State>());

            log.Log("Finish game mode scene bootstraping");
            
            // go to the first scene state
            sceneStateMachine.Enter<StartGameMode1State>();
        }
    }
}