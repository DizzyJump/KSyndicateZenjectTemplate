﻿using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameMode1State : IState
    {
        private ILoadingCurtain loadingCurtain;
        private ISceneLoader sceneLoader;
        
        public async void Enter()
        {
            Debug.Log("Game mode 1 state enter");
            loadingCurtain.Show();
            await sceneLoader.Load(InfrastructureAssetPath.GameMode1Scene);
            loadingCurtain.Hide();
        }

        public void Exit()
        {
            
        }
    }
}