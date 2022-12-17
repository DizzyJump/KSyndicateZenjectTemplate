using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly ISaveLoadService saveLoadService;
        private readonly IEnumerable<IProgressReader> progressReaderServices;
        private readonly IPlayerProgressService progressService;

        public LoadPlayerProgressState(IGameStateMachine gameStateMachine, IPlayerProgressService progressService, ISaveLoadService saveLoadService, IEnumerable<IProgressReader> progressReaderServices)
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
            
            gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
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
            
            return progress;
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, LoadPlayerProgressState> { }
    }
}