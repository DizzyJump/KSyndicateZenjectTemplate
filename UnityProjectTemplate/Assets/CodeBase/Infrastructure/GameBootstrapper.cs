using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine gameStateMachine;

        [Inject]
        void Construct(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            gameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}