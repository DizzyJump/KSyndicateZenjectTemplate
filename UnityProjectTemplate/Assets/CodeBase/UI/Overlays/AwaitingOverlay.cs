using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Overlays
{
    public class AwaitingOverlay : MonoBehaviour, IAwaitingOverlay
    {
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Canvas canvas;

        private void Awake() => 
            Hide();

        public void Show(string withMessage)
        {
            message.text = withMessage;
            canvas.enabled = true;
        }

        public void Hide() => canvas.enabled = false;
    }
}