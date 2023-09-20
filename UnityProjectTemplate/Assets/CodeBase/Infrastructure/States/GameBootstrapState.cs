using System.Threading.Tasks;
using CodeBase.Services.AdsService;
using CodeBase.Services.AnalyticsService;
using CodeBase.Services.LogService;
using CodeBase.Services.StaticDataService;
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

        public GameBootstrapState(GameStateMachine gameStateMachine,
            IAdsService adsService,
            IStaticDataService staticDataService,
            IAnalyticsService analyticsService,
            ILogService log)
        {
            this.adsService = adsService;
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
            this.analyticsService = analyticsService;
            this.log = log;
        }

        public void Enter()
        {
            log.Log("BootstrapState Enter");
            
            InitServices();
            
            gameStateMachine.Enter<GameLoadingState>();
        }

        private async void InitServices()
        {
            // init mandatory global services here
            analyticsService.Initialize();
            staticDataService.Initialize();
            adsService.Initialize();
        }

        public void Exit()
        {
        }
    }
}