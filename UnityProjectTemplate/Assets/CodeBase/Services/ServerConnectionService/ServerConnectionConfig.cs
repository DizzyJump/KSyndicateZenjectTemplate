using UnityEngine;

namespace CodeBase.Services.ServerConnectionService
{
    [CreateAssetMenu(menuName = "Configs/Services/ConnectionService")]
    public class ServerConnectionConfig : ScriptableObject
    {
        // you can add in this config any necessary information for your case.
        // following settings just for demonstration purpose
        public string ServerAddress;
        public int Port;
        public float ConnectionTimeout;
    }
}