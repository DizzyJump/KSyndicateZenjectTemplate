using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.AdsService;
using CodeBase.Services.AnalyticsService;
using CodeBase.Services.LogService;
using CodeBase.Services.StaticDataService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly IAdsService adsService;
        private readonly IStaticDataService staticDataService;
        private readonly IAnalyticsService analyticsService;
        private readonly ILogService log;
        private readonly IAssetProvider assetProvider;

        public GameBootstrapState(GameStateMachine gameStateMachine,
            IAdsService adsService,
            IStaticDataService staticDataService,
            IAnalyticsService analyticsService,
            IAssetProvider assetProvider,
            ILogService log)
        {
            this.adsService = adsService;
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
            this.analyticsService = analyticsService;
            this.assetProvider = assetProvider;
            this.log = log;
        }

        public async void Enter()
        {
            log.Log("BootstrapState Enter");
            
            await InitServices();
            
            gameStateMachine.Enter<GameLoadingState>();
        }

        private async UniTask InitServices()
        {
            // init mandatory global services here
            await assetProvider.Initialize();
            await staticDataService.Initialize();
            analyticsService.Initialize();
            adsService.Initialize();
        }

        public void Exit()
        {
        }
    }
}