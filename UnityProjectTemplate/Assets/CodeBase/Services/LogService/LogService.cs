using UnityEngine;

namespace CodeBase.Services.LogService
{
    public class LogService : ILogService
    {
        public void Log(string msg) => 
            Debug.Log(msg);
        
        public void LogError(string msg) => 
            Debug.LogError(msg);

        public void LogWarning(string msg) => 
            Debug.LogWarning(msg);
    }
}