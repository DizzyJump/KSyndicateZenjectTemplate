using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly ISceneLoader sceneLoader;
        private readonly ILoadingCurtain loadingCurtain;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"LoadLevelState enter. Load scene {sceneName}");
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("LoadLevelState exit");
        }

        private void OnLoaded()
        {
            Debug.Log("LoadLevelState OnLoaded");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}