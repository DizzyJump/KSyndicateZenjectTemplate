using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.PrivatePolicyAccept
{
    public class PrivatePolicyAcceptWindow : WindowBase
    {
        [SerializeField] private Toggle toggle;

        protected override void Initialize()
        {
            base.Initialize();
            toggle.isOn = Progress.PrivatePolicyAccepted;
            UpdateCloseButton(false);
        }

        protected override void SubscribeUpdates()
        {
            base.SubscribeUpdates();
            toggle.onValueChanged.AddListener(OnToggleChange);
        }

        void OnToggleChange(bool value)
        {
            Progress.PrivatePolicyAccepted = value;
            Debug.Log($"private policy acceptance: {value}");
            UpdateCloseButton(value);
        }

        void UpdateCloseButton(bool enable) => 
            CloseButton.interactable = enable;

        protected override void Cleanup()
        {
            base.Cleanup();
            toggle.onValueChanged.RemoveListener(OnToggleChange);
        }
    }
}