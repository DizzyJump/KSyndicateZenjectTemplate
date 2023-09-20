using System.Threading;
using System.Threading.Tasks;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.PopUps
{
    public abstract class PopUpBase<TResult, TInitializeData> : MonoBehaviour
    {
        [SerializeField] private Canvas popupCanvas;
        
        protected IPersistentProgressService ProgressService;
        protected PlayerProgress Progress => ProgressService.Progress;

        private UniTaskCompletionSource<TResult> taskCompletionSource;

        [Inject]
        public void Construct(IPersistentProgressService progressService) => 
            ProgressService = progressService;

        private void Awake() => 
            OnAwake();

        public UniTask<TResult> Show(TInitializeData with)
        {
            taskCompletionSource = new UniTaskCompletionSource<TResult>();
            Initialize(with);
            SubscribeUpdates();
            popupCanvas.enabled = true;
            return taskCompletionSource.Task;
        }

        public void Hide() => popupCanvas.enabled = false;
        
        protected void SetPopUpResult(TResult result) =>
            taskCompletionSource.TrySetResult(result);

        private void OnDestroy() => 
            Cleanup();

        protected virtual void OnAwake() => Hide();
        protected virtual void Initialize(TInitializeData with){}
        protected virtual void SubscribeUpdates(){}
        protected virtual void Cleanup(){}
    }
}