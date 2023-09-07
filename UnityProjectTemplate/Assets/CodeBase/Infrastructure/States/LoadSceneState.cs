using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadSceneState : IPaylodedState<string>
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly ISceneLoader sceneLoader;
        private readonly ILoadingCurtain loadingCurtain;

        public LoadSceneState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"LoadSceneState enter. Load scene {sceneName}");
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("LoadSceneState exit");
        }

        private void OnLoaded()
        {
            Debug.Log("LoadSceneState OnLoaded");
        }
    }
}