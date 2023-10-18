using CodeBase.Gameplay.States;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using Zenject;

namespace CodeBase.Gameplay
{
    public class GameplaySceneBootstraper : IInitializable
    {
        private readonly SceneStateMachine sceneStateMachine;
        private readonly StatesFactory statesFactory;
        private readonly ILogService log;

        public GameplaySceneBootstraper(SceneStateMachine sceneStateMachine, StatesFactory statesFactory, ILogService log)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.statesFactory = statesFactory;
            this.log = log;
        }

        public void Initialize()
        {
            log.Log("Start game mode scene bootstraping");

            sceneStateMachine.RegisterState(statesFactory.Create<StartGameplayState>());
            sceneStateMachine.RegisterState(statesFactory.Create<PlayGameplayState>());
            sceneStateMachine.RegisterState(statesFactory.Create<WinGameplayState>());
            sceneStateMachine.RegisterState(statesFactory.Create<FailGameplayState>());
            sceneStateMachine.RegisterState(statesFactory.Create<FinishGameplayState>());

            log.Log("Finish game mode scene bootstraping");
            
            // go to the first scene state
            sceneStateMachine.Enter<StartGameplayState>();
        }
    }
}