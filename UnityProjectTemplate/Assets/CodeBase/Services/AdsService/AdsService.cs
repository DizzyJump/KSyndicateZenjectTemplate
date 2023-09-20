using System;
using CodeBase.Services.LogService;
using UnityEngine;

namespace CodeBase.Services.AdsService
{
    public class AdsService : IAdsService
    {
        public event Action RewardedVideoReady;

        public bool IsRewardedVideoReady { get; }

        private readonly ILogService log;

        public AdsService(ILogService log)
        {
            this.log = log;
        }

        public void Initialize()
        {
            log.LogWarning("Initialization of ads service isn't implemented yet");
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            log.LogWarning("Showing of ads isn't implemented yet");
        }
    }
}