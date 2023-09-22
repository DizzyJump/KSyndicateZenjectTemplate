using System;
using CodeBase.Services.LocalizationService;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Overlays
{
    public class AwaitingOverlay : MonoBehaviour, IAwaitingOverlay
    {
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Canvas canvas;

        private ILocalizationService localizationService;

        [Inject]
        public void Construct(ILocalizationService localizationService) => 
            this.localizationService = localizationService;

        private void Awake() => 
            Hide();

        public void Show(string withMessage)
        {
            message.text = localizationService.Translate(withMessage);
            canvas.enabled = true;
        }

        public void Hide() => canvas.enabled = false;

        public class Factory : PlaceholderFactory<string, UniTask<AwaitingOverlay>>
        {
        }
    }
}