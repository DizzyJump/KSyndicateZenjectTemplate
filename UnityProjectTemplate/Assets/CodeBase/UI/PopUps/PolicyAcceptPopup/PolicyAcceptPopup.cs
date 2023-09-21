using CodeBase.Services.LocalizationService;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.PopUps.PolicyAcceptPopup
{
    public class PolicyAcceptPopup : PopUpBase<bool, PolicyAcceptPopupConfig>
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI policyText;
        [SerializeField] private TextMeshProUGUI agreeText;
        [SerializeField] private TextMeshProUGUI buttonText;

        private ILocalizationService localizationService;
        private ILogService log;

        [Inject]
        public void Construct(ILocalizationService localizationService, ILogService log)
        {
            this.localizationService = localizationService;
            this.log = log;
        }

        protected override void Initialize(PolicyAcceptPopupConfig config)
        {
            base.Initialize(config);
            FillData(config);
            SetControlStates();
        }

        private void SetControlStates()
        {
            toggle.isOn = false;
            UpdateCloseButton(false);
        }

        private void FillData(PolicyAcceptPopupConfig config)
        {
            policyText.text = localizationService.Translate(config.PolicyText);
            agreeText.text = localizationService.Translate(config.AgreeText);
            buttonText.text = localizationService.Translate(config.ButtonText);
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            toggle.onValueChanged.AddListener(OnToggleChange);
            button.onClick.AddListener(OnButtonClick);
        }

        void OnToggleChange(bool value)
        {
            log.Log($"Private policy acceptance set to: {value}");
            UpdateCloseButton(value);
        }

        void UpdateCloseButton(bool enable) => 
            button.interactable = enable;

        protected override void Cleanup()
        {
            base.Cleanup();
            toggle.onValueChanged.RemoveListener(OnToggleChange);
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick() => 
            SetPopUpResult(toggle.isOn);

        public class Factory : PlaceholderFactory<string, UniTask<PolicyAcceptPopup>>
        {
        }
    }
}