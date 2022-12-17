using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;

namespace CodeBase.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private IEnumerable<IProgressSaver> saverServices;
        private IPlayerProgressService playerProgressService;

        public SaveLoadService(IEnumerable<IProgressSaver> saverServices, IPlayerProgressService playerProgressService)
        {
            this.saverServices = saverServices;
            this.playerProgressService = playerProgressService;
        }

        public void SaveProgress()
        {
            foreach (var saver in saverServices) 
                saver.UpdateProgress(playerProgressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, playerProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}