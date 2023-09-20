using CodeBase.Services.LogService;
using CodeBase.Services.ServerConnectionService;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    // This service incapsulate logic of uploading configs and give convenient API
    // for all consumers to receive necessary configs
    public class StaticDataService : IStaticDataService
    {
        private ServerConnectionConfig serverConnectionConfig;

        private readonly ILogService log;

        public ServerConnectionConfig ServerConnectionConfig => serverConnectionConfig;

        public StaticDataService(ILogService log) => 
            this.log = log;

        public void Initialize()
        {
            // load your configs here

            serverConnectionConfig = Resources.Load<ServerConnectionConfig>("Configs/Services/Server Connection Config");
            
            log.Log("Static data loaded");
        }
    }
}