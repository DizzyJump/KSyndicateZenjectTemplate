using UnityEngine;

namespace CodeBase.UI.PopUps.PolicyAcceptPopup
{
    [CreateAssetMenu(menuName = "Configs/UI/Popups/PolicyAcceptPopupConfig")]
    public class PolicyAcceptPopupConfig : ScriptableObject
    {
        public PolicyAcceptPopupTypes Type;
        [TextArea(5, 10)] public string PolicyText;
        [TextArea(1, 3)] public string AgreeText;
        [TextArea(1, 1)]public string ButtonText;
    }
}