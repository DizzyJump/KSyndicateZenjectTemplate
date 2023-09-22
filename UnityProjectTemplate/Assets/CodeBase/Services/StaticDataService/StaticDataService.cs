using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.LogService;
using CodeBase.Services.ServerConnectionService;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Services.StaticDataService
{
    // This service incapsulate logic of uploading configs and give convenient API
    // for all consumers to receive necessary configs
    public class StaticDataService : IStaticDataService
    {
        public ServerConnectionConfig ServerConnectionConfig { get; private set; }
        private readonly ILogService log;
        private IAssetProvider assetProvider;
        private Dictionary<int, PolicyAcceptPopupConfig> policyAcceptConfigs;

        public StaticDataService(ILogService log, IAssetProvider assetProvider)
        {
            this.log = log;
            this.assetProvider = assetProvider;
        }

        public async UniTask InitializeAsync()
        {
            // load your configs here
            List<UniTask> tasks = new List<UniTask>();
            tasks.Add(LoadServerConfigs());
            tasks.Add(LoadPolicyAcceptConfigs());

            await UniTask.WhenAll(tasks);
            log.Log("Static data loaded");
        }

        private async UniTask LoadPolicyAcceptConfigs()
        {
            var configs = await GetConfigs<PolicyAcceptPopupConfig>();
            policyAcceptConfigs = configs.ToDictionary(config => (int)config.Type, config => config);
        }

        private async UniTask LoadServerConfigs()
        {
            var configs = await GetConfigs<ServerConnectionConfig>();
            if(configs.Length > 0)
                ServerConnectionConfig = configs.First();
            else
                log.LogError("There are no server connection config founded!");
        }

        private async UniTask<List<string>> GetConfigKeys<TConfig>() => 
            await assetProvider.GetAssetsListByLabel<TConfig>(AssetLabels.Configs);

        private async UniTask<TConfig[]> GetConfigs<TConfig>() where TConfig : class
        {
            var keys = await GetConfigKeys<TConfig>();
            return await assetProvider.LoadAll<TConfig>(keys);
        }

        public PolicyAcceptPopupConfig GetPolicyAcceptPopupConfig(PolicyAcceptPopupTypes type) =>
            policyAcceptConfigs[(int)type];
    }
}