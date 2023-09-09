using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly ISaveLoadService saveLoadService;
        private readonly IEnumerable<IProgressReader> progressReaderServices;
        private readonly IPersistentProgressService progressService;

        public LoadPlayerProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IEnumerable<IProgressReader> progressReaderServices)
        {
            this.gameStateMachine = gameStateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
            this.progressReaderServices = progressReaderServices;
        }

        public void Enter()
        {
            Debug.Log("LoadPlayerProgressState enter");
            
            var progress = LoadProgressOrInitNew();
            
            NotifyProgressReaderServices(progress);
            
            gameStateMachine.Enter<LoadSceneState, string>(InfrastructureAssetPath.GameHubScene);
        }

        private void NotifyProgressReaderServices(PlayerProgress progress)
        {
            foreach (var reader in progressReaderServices)
                reader.LoadProgress(progress);
        }

        public void Exit()
        {
            Debug.Log("LoadPlayerProgressState exit");
            
        }

        private PlayerProgress LoadProgressOrInitNew()
        {
            progressService.Progress = 
                saveLoadService.LoadProgress() 
                ?? NewProgress();
            return progressService.Progress;
        }

        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress();

            Debug.Log("Init new player progress");
            // init start state of progress here

            progress.PrivatePolicyAccepted = false;
            
            return progress;
        }
    }
}