using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase.UI.PopUps.ErrorPopup
{
    public class ErrorPopup : PopUpBase<bool, ErrorPopupConfig>
    {
        [SerializeField] private TextMeshProUGUI headerText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Button button;
        
        protected override void Initialize(ErrorPopupConfig with)
        {
            base.Initialize(with);
            
            headerText.text = with.HeaderText;
            messageText.text = with.MessageText;
            buttonText.text = with.ButtonText;
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
    }
}