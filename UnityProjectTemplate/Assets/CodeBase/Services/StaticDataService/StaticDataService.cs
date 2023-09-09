using CodeBase.Services.ServerConnectionService;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private ServerConnectionConfig serverConnectionConfig;

        public ServerConnectionConfig ServerConnectionConfig => serverConnectionConfig;

        public void Initialize()
        {
            // load your configs here

            serverConnectionConfig = Resources.Load<ServerConnectionConfig>("Configs/Services/Server Connection Config");
            
            Debug.Log("Static data loaded");
        }
    }
}