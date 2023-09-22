using CodeBase.Services.LocalizationService;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.PopUps.ErrorPopup
{
    public class ErrorPopup : PopUpBase<bool, ErrorPopupConfig>
    {
        [SerializeField] private TextMeshProUGUI headerText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Button button;

        private ILocalizationService localizationService;

        public void Construct(ILocalizationService localizationService) =>
            this.localizationService = localizationService;
        
        protected override void Initialize(ErrorPopupConfig with)
        {
            base.Initialize(with);
            
            headerText.text = localizationService.Translate(with.HeaderText);
            messageText.text = localizationService.Translate(with.MessageText);
            buttonText.text = localizationService.Translate(with.ButtonText);
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick() => 
            SetPopUpResult(true);

        protected override void Cleanup()
        {
            base.Cleanup();
            button.onClick.RemoveListener(OnClick);
        }

        public class Factory : PlaceholderFactory<string, UniTask<ErrorPopup>>
        {
        }
    }
}