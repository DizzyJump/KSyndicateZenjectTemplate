using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneProvider : ISceneProvider
    {
        private ILogService log;

        private string currentScene;
        private Dictionary<string, AsyncOperationHandle<SceneInstance>> loadedScenes = new();

        public SceneProvider(ILogService log) => 
            this.log = log;

        public async UniTask Load(string nextScene)
        {
            AsyncOperationHandle<SceneInstance> handler;
            if (!loadedScenes.TryGetValue(nextScene, out handler))
            {
                handler = Addressables.LoadSceneAsync(nextScene, LoadSceneMode.Single, false);
                loadedScenes.Add(nextScene, handler);
            }

            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
        }

        public async UniTask Unload(string scene)
        {
            if (loadedScenes.TryGetValue(scene, out var handler))
            {
                loadedScenes.Remove(scene);
                Addressables.UnloadSceneAsync(handler);
            }
        }
    }
}