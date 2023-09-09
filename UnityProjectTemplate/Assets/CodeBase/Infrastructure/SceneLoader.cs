using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(string nextScene)
        {
            if (SceneManager.GetActiveScene().name != nextScene)
            {
                AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
                await waitNextScene.ToUniTask();
            }
        }
    }
}