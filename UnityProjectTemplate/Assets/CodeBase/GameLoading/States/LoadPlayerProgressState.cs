using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Data;
using CodeBase.Infrastructure.GameLoading.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using CodeBase.UI.Overlays;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private readonly SceneStateMachine sceneStateMachine;
        private readonly ISaveLoadService saveLoadService;
        private readonly IEnumerable<IProgressReader> progressReaderServices;
        private readonly IPersistentProgressService progressService;
        private IAwaitingOverlay awaitingOverlay;

        public LoadPlayerProgressState(SceneStateMachine sceneStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IEnumerable<IProgressReader> progressReaderServices, IAwaitingOverlay awaitingOverlay)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
            this.progressReaderServices = progressReaderServices;
            this.awaitingOverlay = awaitingOverlay;
        }

        public async void Enter()
        {
            Debug.Log("LoadPlayerProgressState enter");
            
            awaitingOverlay.Show("Loading player progress...");
            
            var progress = LoadProgressOrInitNew();
            
            NotifyProgressReaderServices(progress);

            await UniTask.WaitForSeconds(1f); // just for demonstrate concept with overlay. You can remove it. 
            awaitingOverlay.Hide();
            
            sceneStateMachine.Enter<PrivatePolicyState>();
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