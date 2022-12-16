using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadGameSaveState : IState
    {
        private IGameStateMachine gameStateMachine;

        public LoadGameSaveState(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public void Exit()
        {
            Debug.Log("LoadGameSaveState exit");
            gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.GameHubScene);
        }

        public void Enter()
        {
            Debug.Log("LoadGameSaveState enter");
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, LoadGameSaveState> { }
    }
}