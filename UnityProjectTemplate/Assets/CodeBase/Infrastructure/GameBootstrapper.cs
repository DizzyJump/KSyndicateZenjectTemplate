using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine gameStateMachine;
        private StatesFactory statesFactory;

        [Inject]
        void Construct(GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.statesFactory = statesFactory;
        }
        
        private void Start()
        {
            gameStateMachine.RegisterState(statesFactory.Create<GameBootstrapState>());
            gameStateMachine.RegisterState(statesFactory.Create<GameLoadingState>());
            gameStateMachine.RegisterState(statesFactory.Create<GameHubState>());
            gameStateMachine.RegisterState(statesFactory.Create<GameplayState>());
            
            gameStateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}