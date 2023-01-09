using System;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

namespace CodeBase.UI.Extensions
{
    // implemented by following this guide: https://www.youtube.com/watch?v=U6h6p1tJ7XM
    public struct ButtonAwaiter : INotifyCompletion
    {
        private Button button;
        private Action storedContinuation;

        public ButtonAwaiter(Button button)
        {
            this.button = button;
            storedContinuation = null;
        }

        public bool IsCompleted => false;

        public Button GetResult() => button;
        
        public void OnCompleted(Action continuation)
        {
            storedContinuation = continuation;
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            storedContinuation.Invoke();
            button.onClick.RemoveListener(OnClick);
            storedContinuation = null;
        }
    }
}