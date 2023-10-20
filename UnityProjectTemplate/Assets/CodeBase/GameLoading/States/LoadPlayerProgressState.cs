using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.WalletService;
using CodeBase.UI.Overlays;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.GameLoading.States
{
    public class LoadPlayerProgressState : IState
    {
        private readonly SceneStateMachine sceneStateMachine;
        private readonly ISaveLoadService saveLoadService;
        private readonly IEnumerable<IProgressReader> progressReaderServices;
        private readonly IPersistentProgressService progressService;
        private readonly IAwaitingOverlay awaitingOverlay;
        private readonly ILogService log;

        public LoadPlayerProgressState(SceneStateMachine sceneStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IEnumerable<IProgressReader> progressReaderServices, IAwaitingOverlay awaitingOverlay, ILogService log)
        {
            this.sceneStateMachine = sceneStateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
            this.progressReaderServices = progressReaderServices;
            this.awaitingOverlay = awaitingOverlay;
            this.log = log;
        }

        public async UniTask Enter()
        {
            log.Log("LoadPlayerProgressState enter");
            
            awaitingOverlay.Show("Loading player progress...");
            
            var progress = LoadProgressOrInitNew();
            
            NotifyProgressReaderServices(progress);

            await UniTask.WaitForSeconds(1f); // just for demonstrate concept with overlay. You can remove it. 
            awaitingOverlay.Hide();
            
            sceneStateMachine.Enter<PrivatePolicyState>().Forget();
        }

        private void NotifyProgressReaderServices(PlayerProgress progress)
        {
            foreach (var reader in progressReaderServices)
                reader.LoadProgress(progress);
        }

        public UniTask Exit()
        {
            log.Log("LoadPlayerProgressState exit");
            return default;
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

            log.Log("Init new player progress");
            // init start state of progress here

            progress.PrivatePolicyAccepted = false;
            progress.GDPRPolicyAccepted = false;
            progress.WalletsData = new WalletsData(new Dictionary<int, long>());
            
            return progress;
        }
    }
}